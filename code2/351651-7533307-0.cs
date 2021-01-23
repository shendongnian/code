    // Get a collection of all validators to check, sort of like this
    var allValidators = new[] { validator1, validator2, validator3 };
    foreach (var validator in allValidators)
    {
        validator.Validate();
        var ctrl = (WebControl)Page.FindControl(validator.ControlToValidate);
        ctrl.BackColor = validator.IsValid ? Colors.Red : Colors.White;
    }
