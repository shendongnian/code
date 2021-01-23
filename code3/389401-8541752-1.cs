    public ViewResult Index()
    { // breakpoint
        var comments = GetComments(); // debug and inspect the value of this variable
        return View(comments);
    }
    [HttpPost]
    public ActionResult Index(int[] AllIds)
    {
        if (AllIds != null)
        {
            foreach (int id in AllIds)
            {
               // do stuff
            }
        }
        return RedirectToAction("Index"); // breakpoint
    } 
