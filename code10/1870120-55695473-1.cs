    [HttpPost]
    [MultipleButton(Name = "action", Argument = "view")]
    public ActionResult ViewDetail(string[] viewId)
    {
        return RedirectToAction("ViewDetails");
    }
