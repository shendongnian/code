    public ActionResult Detail()
    {
        return View();
    }
    public ActionResult SubmitTicket()
    {
        RedirectToAction("Detail")
    }
