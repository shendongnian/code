    public ActionResult Index()
    {
        return View(new GoodStudent { Age = 13, Name = "John Smith" });
    }
    
    [HttpPost]
    public ActionResult Index(Student student)
    {
        return View(student);
    }
