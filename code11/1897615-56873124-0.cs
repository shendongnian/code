       public ActionResult Index(string graduationStatus)
        {
          var graduates = db.Graduated_Students.Where(student => student.GraduationStatus != null);
            ViewBag.GraduationStatus = new SelectList(db.Graduated_Students.Select(m => m.GraduationStatus).Distinct().ToList());
             if(!string.IsNullOrEmpty)
             {
                 graduates = graduates .Where(student => student.GraduationStatus == graduationStatus);
             }
            
            return View(graduates.ToList());
        }
