    public ActionResult Detail()
    {
        return View();
    }
    public ActionResult SubmitTicket()
    {
        return RedirectToAction("Detail")
    }
