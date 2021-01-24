    [Required(ErrorMessage = "This field should be filled in")]
    [RegularExpression(@"\w+(@)[a-zA-z]+(\.)[a-zA-z]+", ErrorMessage = ("Use the right email format"))]
    public string Email { get; set; }
    public string Error => throw new NotImplementedException();
    public string this[string columnName]
    {
        get
        {
            string error = String.Empty;
            switch (columnName)
            {
                case "Email":
                    return ValidateModelProperty(Email, columnName);
            }
            return error;
        }
    }
    private string ValidateModelProperty(object value, string propertyName)
    {
        ICollection<ValidationResult> validationResults = new List<ValidationResult>();
        ValidationContext validationContext =
            new ValidationContext(this, null, null) { MemberName = propertyName };
        if (!Validator.TryValidateProperty(value, validationContext, validationResults))
            foreach (ValidationResult validationResult in validationResults)
                return validationResult.ErrorMessage;
        return null;
    }
