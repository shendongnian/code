    [HttpPost]
    public ActionResult ValidateTextBox(Dummy data)
    {
        int result = 0;
    
        if (!int.TryParse(data.input, out result)) {
            return Json(new { Result = false, Message = "Please enter in numbers" });
        }
        return Json(new { Result = true, Message = "Success" });
    }
