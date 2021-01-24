    var settings = configuration.GetSection("Settings").Get<EmailConfig>();
    //validate
    var validationResults = new List<ValidationResult>();
    var validationContext = new ValidationContext(settings, serviceProvider: null, items: null);
    if (!Validator.TryValidateObject(settings, validationContext, validationResults, 
            validateAllProperties: true)) {
        //...Fail early
        //will have the validation results in the list
    }
    services.AddSingleton(settings);
