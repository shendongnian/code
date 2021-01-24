    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,AspNetUserFk,Date,FirstName,LastName")] Bookings bookings, ICollection<AttendingPeople> attendingPeople)
    {
        if (ModelState.IsValid)
        {
            db.Entry(bookings).State = EntityState.Modified;
            db.SaveChanges();
            foreach (var item in attendingPeople)
            {
                item.BookingId = bookings.Id;
                db.Entry(item).State = EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.AspNetUserFk = new SelectList(db.AspNetUsers, "Id", "Email", bookings.AspNetUserFk);
        bookings = db.Bookings.Include(at => at.AttendingPeople).SingleOrDefault(b => b.Id == bookings.Id)
        return View(bookings);
    }
