    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Legoland.Models;
    
    namespace Legoland.Controllers
    {
        public class MagazynController : Controller
        {
            private LegolandEntities db = new LegolandEntities();
    
            // GET: Magazyn
            public ActionResult Index()
            {
                var magazyn = db.Magazyn.Include(m => m.xxx).Include(m => m.Person);
                return View(magazyn.ToList());
            }
    
            // GET: Magazyn/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Magazyn magazyn = db.Magazyn.Find(id);
                if (magazyn == null)
                {
                    return HttpNotFound();
                }
                return View(magazyn);
            }
    
            // GET: Magazyn/Create
            public ActionResult Create()
            {
                ViewBag.Idxxx = new SelectList(db.xxx, "Id", "xxx");
                ViewBag.IdPerson = new SelectList(db.Person, "Id", "Name", "LastName");
                return View();
            }
    
            // POST: Magazyn/Create
           
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "Id,IdPerson,Idxxx,yyy,zzzz")] Magazyn magazyn)
            {
                if (ModelState.IsValid)
                {
                    db.Magazyn.Add(magazyn);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
                ViewBag.Idxxx = new SelectList(db.xxx, "Id", "xxx", magazyn.Idxxx);
                ViewBag.IdPerson = new SelectList(db.Person, "Id", "Name", "LastName", magazyn.Person);
                return View(magazyn);
            }
    
            // GET: Magazyn/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Magazyn magazyn = db.Magazyn.Find(id);
                if (magazyn == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Idxxx = new SelectList(db.xxx, "Id", "xxx", magazyn.Idxxx);
                var selectList = db.Person.Select(x => new SelectListItem { Text = $"{x.Name} - {x.LastName}", Value = x.Id.ToString() });
                ViewBag.IdPerson = new SelectList(selectList, "Value", "Text");
                return View(magazyn);
            }
    
            // POST: Magazyn/Edit/5
           
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Id,IdPerson,Idxxx,yyy,zzz")] Magazyn magazyn)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(magazyn).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Idxxx = new SelectList(db.xxx, "Id", "yyy", magazyn.Idxxx);
                var selectList = db.Person.Select(x => new SelectListItem { Text = $"{x.Name} - {x.LastName}", Value = x.Id.ToString() });
                ViewBag.IdPerson = new SelectList(selectList, "Value", "Text");
                return View(magazyn);
            }
    
            // GET: Magazyn/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Magazyn magazyn = db.Magazyn.Find(id);
                if (magazyn == null)
                {
                    return HttpNotFound();
                }
                return View(magazyn);
            }
    
            // POST: Magazyn/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                Magazyn magazyn = db.Magazyn.Find(id);
                db.Magazyn.Remove(magazyn);
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
    
       
        
