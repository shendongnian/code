    public ActionResult Index(DateTime? dateFrom, DateTime? dateTo)
    {
        ViewBag.DateFrom = dateFrom?.ToString("yyyy-mm-dd");
        return View();
    }
