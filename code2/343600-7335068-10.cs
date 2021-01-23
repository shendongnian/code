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
        
        var firstErrorBatch = GetEmptyStringErrors(
            new[]{
                new InputCheckPair(txtOperatorID, "A"),
                new InputCheckPair(cboProject, "B"),
                new InputCheckPair(cboFilterType, "C"),
                new InputCheckPair(cboInstType, "D"),
            })
            .ToList();
        if(firstErrorBatch.Count > 0)
        {
            return ValidationResult.Errors(firstErrorBatch);
        }
            
        var secondErrorBatch = GetEmptyStringErrors(
            new[]{
                new InputCheckPair(txtFilterID, "E"),
                new InputCheckPair(txtLot, "D"),
            })
            .ToList();
        return secondErrorBatch.Count > 0 
            ? ValidationResult.Errors(secondErrorBatch) 
            : ValidationResult.Success();
    }
    
    private class InputCheckPair
    {
        public InputCheckPair(TextBox input, string errorIfEmpty)
        {
            Input = input;
            ErrorIfEmpty = errorIfEmpty;
        }
        public TextBox Input {get; private set;}
        public string ErrorIfEmpty{get; private set;}
    }
    
    public IEnumerable<string> GetEmptyStringErrors(IEnumerable<InputCheckPair> pairs)
    {
        return from p in pairs where p.Input.Text.Length == 0 select p.ErrorIfEmpty;
    }
