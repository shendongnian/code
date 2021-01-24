    private readonly MyDbContext context;
    // Constructor and other methods omitted
    [HttpGet]
    public ActionResult Register(int seminarId)
    {
        var seminar = context.Seminars.Single(x => x.Id == seminarId);
        return View(seminar);
    }
    [HttpPost]
    public ActionResult Register(Enrollment enrollment)
    {
        context.Enrollment.Add(enrollment);
        return RedirectToAction("index", "Seminar");
    }
