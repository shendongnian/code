    [HttpPost]
    public ActionResult AddField(SomeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // the client sent an invalid data
            return Json(new { IsSuccess = false });
        }
        // the model passed validation => do some processing with this model
        return Json(new { IsSuccess = true });
    }
