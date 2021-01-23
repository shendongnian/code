    public JsonResult Validate( CustomPostModel model )
    {
        JsonResultObject result = new JsonResultObject()
        {
          ok = false,
          message = "Some custom error message here",
          data = model
        }
        return Json(result);
    }
