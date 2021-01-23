    var cfgSrc = new FileConfigurationSource("Validations.xml");
    var factory = ConfigurationValidatorFactory.FromConfigurationSource(cfgSrc);
    Validator val = factory.CreateValidator<MyObj>();
    MyObj myObj = new MyObj();
    myObj.Name = "Swiper McFoxy";
    ValidationResults results = new ValidationResults();
    foreach (ValidationResult result in val.Validate(myObj))
    {
        results.AddResult(
            new ValidationResult(
                GetMessage<MyObj>(result.Message, new CultureInfo("en")),
                result.Target,
                result.Key,
                result.Tag,
                result.Validator,
                result.NestedValidationResults));
    }
