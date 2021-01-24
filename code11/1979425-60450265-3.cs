    public ActionResult Register(int? id)           
    {
      //Check if TempData is not null
      if (TempData["studentid"] != null)
      {
        id=(int)TempData["studentid"];
      }
      if (id == null)
      {
         return RedirectToAction("Index");
      }
      Class_Schedule class_Schedule = db.Class_Schedule.Find(id);
      if (class_Schedule == null)
      {
         return RedirectToAction("Index");
      }
      //This is the collects the class_schedule ID to make the attendance specific for each class ViewBag.CSid = id;
      ViewBag.studentID = new SelectList(db.Students, "StudentID", "Full_Name");
      ViewBag.instructorID = new SelectList(db.Instructors, "InstructorID", "Name");
      var attendances = db.Attendances;
    
      return View(attendances.ToList());
    }
