    public ValidationResult Validate(Sender sender)
    {
        if (!(InitialUsageSettings.zeroed || sender.Equals(btnZero)))
        {   
            return ValidationResult.Error("A");
        }
        if (!(InitialUsageSettings.StandardFilterRun || sender.Equals(btnStandard)))
        {   
            return ValidationResult.Error("Z");
        }
        // Etc...
        if (txtOperatorID.Text.Length == 0)
        {
            errors.Add("A");
        }
        if (cboProject.Text.Length == 0)
        {
            errors.Add("B");
        }
        if (cboFilterType.Text.Length == 0)
        {
            errors.Add("C");
        }
        if (cboInstType.Text.Length == 0)
        {
            errors.Add("D");
        }
        if(errors.Count > 0)
        {
            return ValidationResult.Errors(errors);
        }
        if (txtFilterID.Text.Length == 0)
        {
            errors.Add("E");
        }
        if (txtLot.Text.Length == 0)
        {
            errors.Add("D");
        }
        return errors.Count > 0 
            ? ValidationResult.Errors(errors) 
            : ValidationResult.Success();
    }
