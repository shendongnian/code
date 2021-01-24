    if (buttonType == "Validate")
    {
        var validator = new DOBvalidator(18);
        var isValid = validator.IsValid(information.DOBP);
        //rest of logic              
    }
