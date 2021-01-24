    if (buttonType == "Validate")
    {
        var validator = new DOBvalidator(18);
        var isValid = validator.IsValid(information.DOBP);
        if(!isValid)
        {
             ModelState.AddModelError("DOBP", validator.ErrorMessage);
        }              
    }
