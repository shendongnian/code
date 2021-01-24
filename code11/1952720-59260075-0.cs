    public ActionResult Save(returncar recar)
        {
            if (ModelState.IsValid)
            {
                db.returncars.Add(recar);
                //I realized that the carno is unique
                var car= db.cars.SingleOrDefault(e => e.carno == recar.carno);
                if(car == null)
                return HttpNotFound("CarNo is not valid");
 
                car.Available = "yes";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          return View(recar);
        }
