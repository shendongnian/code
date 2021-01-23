    [HttpPost]
    public ActionResult SelectName(string SelectedName)
    {
       ...
       ViewData["SelectedText"] = "some text";
       return View();
    }
