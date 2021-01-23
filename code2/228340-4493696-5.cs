    [HttpPost]
    public JsonResult Action(FormCollection formCollection)
    {
        NameValueCollection test = HttpContext.Request.Form;
        return Json(test[0]);
    }
