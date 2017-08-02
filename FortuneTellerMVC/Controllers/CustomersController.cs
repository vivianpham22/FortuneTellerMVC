using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerMVC.Models;

namespace FortuneTellerMVC.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            //Console.WriteLine(eoAge);

            if (customer.Age % 2 == 0)
            {
                ViewBag.retireAge = 10;
            }
            else
            {
                ViewBag.retireAge = 20;
            }

            //Sibilings & Location

            if (customer.NumberOfSilbings == 0)
            {
                ViewBag.home = "San Diego";
            }
            else if (customer.NumberOfSilbings == 1)
            {
                ViewBag.home = "Miami";
            }
            else if (customer.NumberOfSilbings == 2)
            {
                ViewBag.home = "Alaska";
            }
            else if (customer.NumberOfSilbings == 3)
            {
                ViewBag.home = "Mexico";
            }
            else if (customer.NumberOfSilbings > 3)
            {
                ViewBag.home = "Michigan";
            }
            else
            {
                ViewBag.home = "Little Box";
            }

            //Transportation 
            if (customer.FavoriteColor == "red")
            {
                ViewBag.transportation = "bike";
            }
            else if (customer.FavoriteColor == "orange")
            {
                ViewBag.transportation = "jet ski";
            }
            else if (customer.FavoriteColor == "yellow")
            {
                ViewBag.transportation = "car";
            }
            else if (customer.FavoriteColor == "green")
            {
                ViewBag.transportation = "skateboard";
            }
            else if (customer.FavoriteColor == "blue")
            {
                ViewBag.transportation = "boat";
            }
            else if (customer.FavoriteColor == "indigo")
            {
                ViewBag.transportation = "plane";
            }
            else if (customer.FavoriteColor == "violet")
            {
                ViewBag.transportation = "scooter";
            }
            switch (customer.BirthMonth)
            {
                case "january":
                    ViewBag.BirthMonth = 1;
                    break;
                case "february":
                    ViewBag.BirthMonth = 2;
                    break;
                case "march":
                    ViewBag.BirthMonth = 3;
                    break;
                case "april":
                    ViewBag.BirthMonth = 4;
                    break;
                case "may":
                    ViewBag.BirthMonth = 5;
                    break;
                case "june":
                    ViewBag.BirthMonth = 6;
                    break;
                case "july":
                    ViewBag.BirthMonth = 7;
                    break;
                case "august":
                    ViewBag.BirthMonth = 8;
                    break;
                case "september":
                    ViewBag.BirthMonth = 9;
                    break;
                case "october":
                    ViewBag.BirthMonth = 10;
                    break;
                case "november":
                    ViewBag.BirthMonth = 11;
                    break;
                case "december":
                    ViewBag.BirthMonth = 12;
                    break;
                default:
                    ViewBag.BirthMonth = 0;
                    break;
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Firstame,LastName,Age,BirthMonth,FavoriteColor,NumberOfSilbings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Firstame,LastName,Age,BirthMonth,FavoriteColor,NumberOfSilbings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
