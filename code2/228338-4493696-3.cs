    [HttpPost]
    public JsonResult Action()
    {
        NameValueCollection test = HttpContext.Request.Form;
        return Json(test[0]);
    }
