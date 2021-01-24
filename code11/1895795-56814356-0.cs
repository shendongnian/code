     [HttpPost]
     public ActionResult Documents(string? graduationStatus)
     {
         var graduates = db.Graduated_Students.Where(student => student.GraduationStatus == graduationStatus);
         return View(graduates.ToList());
     }
    
