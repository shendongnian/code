    public ActionResult OriginatingAction(string account)
    {
        //Some other code
        TempData["data"] = account; 
        return RedirectToAction("RedirectAction");
    }
