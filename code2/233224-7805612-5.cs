    [HttpPost]
    [ReCaptcha]
    public ActionResult MyAction(MyModel model)
    {
       if (!ModelState.IsValid) // Will have a Model Error "ReCaptcha" if the user input is incorrect
          return Json(new { capthcaInvalid = true });
       ... other stuff ...
    }
