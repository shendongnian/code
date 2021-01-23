    [HttpPost]
    public JsonResult(string categoryTitle)
    {
          //Insert category into DB
          //And retrieve unique ID as "value"
          int value = //add to db
          return Json(new {Value = value});
    }
