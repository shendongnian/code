    public ActionResult Report()
    {
        if (Request.IsAjaxRequest())
        {
            //Delay just for demo purpose
            System.Threading.Thread.Sleep(5000);
            return PartialView("_Report");
        }
        else
            return View("Report");
    }
