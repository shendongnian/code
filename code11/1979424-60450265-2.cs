    //Set TempData here
    if (ModelState.IsValid)
    {
      db.Attendances.Add(attendance);
      db.SaveChanges();
      TempData["studentid"]=attendance.StudentID;
      return RedirectToAction("Register");
    }
