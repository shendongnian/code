    [HttpGet]
    public ActionResult Create()
    {
     // example only
     Subject subject = new Subject 
     {
         Id = 1,
         DepartmentId = 1,
         Name = 1,
         Department = new Department() { SingleKey = "Science" }, 
         ShortName = "Science"
     };
     return View(subject);
    }
