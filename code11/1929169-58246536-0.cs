    public ActionResult Create()
    { 
      List<SelectListItem> CourseId = new List<SelectListItem>();
      CourseId.Add(new SelectListItem { Text = "1", Value = "1" });
      CourseId.Add(new SelectListItem { Text = "2", Value = "2" });
      CourseId.Add(new SelectListItem { Text = "3", Value = "3" });
      ViewBag.CourseId = CourseId;
      return View();
    }
    [HttpPost]
    public ActionResult Create(Student stud)
    {
      ViewBag.CourseId = stud.CourseId;
      return View();
    }
