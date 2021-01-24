    public ActionResult Index()
    {
        this.ViewBag.Start = DateTime.Now;
        System.Threading.Thread.Sleep(5000);
        this.ViewBag.End = DateTime.Now;
        return View();
    }
