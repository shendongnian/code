    /// <summary>
    /// Validates a specific named options instance (or all when name is null).
    /// </summary>
    /// <param name="name">The name of the options instance being validated.</param>
    /// <param name="options">The options instance.</param>
    /// <returns>The <see cref="ValidateOptionsResult"/> result.</returns>
    public ValidateOptionsResult Validate(string name, TOptions options)
    {
        // Null name is used to configure all named options.
        if (Name == null || name == Name)
        {
            var validationResults = new List<ValidationResult>();
            if (Validator.TryValidateObject(options,
                new ValidationContext(options, serviceProvider: null, items: null), 
                validationResults, 
                validateAllProperties: true))
            {
                return ValidateOptionsResult.Success;
            }
            return ValidateOptionsResult.Fail(String.Join(Environment.NewLine,
                validationResults.Select(r => "DataAnnotation validation failed for members " +
                    String.Join(", ", r.MemberNames) +
                    " with the error '" + r.ErrorMessage + "'.")));
        }
        // Ignored if not validating this instance.
        return ValidateOptionsResult.Skip;
    }
