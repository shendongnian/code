    [HttpPost("TestName")]
    public JsonResult TestName(string name)
        {
            //your logic
            return Json(name);
        }
