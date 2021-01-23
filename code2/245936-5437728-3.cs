    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Index(IEnumerable<string> checkboxList)
    {
        if (checkboxList != null)
        {
            ViewData["Message"] = "You selected " + checkboxList.Aggregate("", (a, b) => a + " " + b);
        }
        else
        {
            ViewData["Message"] = "You didn't select anything.";
        }
        return View();
    }
