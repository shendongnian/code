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
        
        return ValidationResult.Success();
    }
