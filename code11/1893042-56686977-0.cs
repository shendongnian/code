    private bool _isEmailValid;
    private bool BlockButton()
    {
        return _isEmailValid && IsAppDeveloper == false && IsEndUser == false;
    }
    public string this[string columnName]
    {
        get
        {
            string error = String.Empty;
            switch (columnName)
            {
                case "Email":
                    string s = ValidateModelProperty(Email, columnName);
                    _isEmailValid = string.IsNullOrEmpty(s);
                    SignInCommand.RaiseCanExecuteChanged();
                    return s;
            }
            return error;
        }
    }
    private string ValidateModelProperty(object value, string propertyName)
    {
        ICollection<ValidationResult> validationResults = new List<ValidationResult>();
        ValidationContext validationContext = new ValidationContext(this, null, null) { MemberName = propertyName };
        if (!Validator.TryValidateProperty(value, validationContext, validationResults))
            foreach (ValidationResult validationResult in validationResults)
                return validationResult.ErrorMessage;
        return null;
    }
