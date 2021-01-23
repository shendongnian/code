    [HttpPost]
    public ActionResult ListBoxChange(string listBoxValue)
    {
       string result = GetResult();
       return Json(new {
         Result = result
       });
    }
