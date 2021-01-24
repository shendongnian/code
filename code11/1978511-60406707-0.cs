        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Id,FirstName,LastName,Address,Facility,IsAvailable")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                if(isDuplicateName(doctor.FirstName,doctor.LastName) == false)
                    {
                        db.Doctors.Add(doctor);
                        db.SaveChanges();
                    }else{
                        return RedirectToAction("Index");
                   }
            }
    
            return View(doctor);
        }
