    public class DataAnnotationsModelValidatorEx : DataAnnotationsModelValidator
    {
      public DataAnnotationsModelValidatorEx(
        ModelMetadata metadata, 
        ControllerContext context, 
        ValidationAttribute attribute)
        : base(metadata, context, attribute)
      {
      }
      public override IEnumerable<ModelValidationResult> Validate(object container)
      {
        ValidationContext context = CreateValidationContext(container);
        ValidationResult result = 
          Attribute.GetValidationResult(Metadata.Model, context);
        if (result != ValidationResult.Success)
        {
          yield return new ModelValidationResult
          {
            Message = result.ErrorMessage
          };
        }
      }
      // begin Extensibility
      protected virtual ValidationContext CreateValidationContext(object container)
      {
        IServiceProvider serviceProvider = CreateServiceProvider(container);
        //TODO: add virtual method perhaps for the third parameter?
        ValidationContext context = new ValidationContext(
          container ?? Metadata.Model, 
          serviceProvider, 
          null);
        context.DisplayName = Metadata.GetDisplayName();
        return context;
      }
      protected virtual IServiceProvider CreateServiceProvider(object container)
      {
        IServiceProvider serviceProvider = null;
        IDependant dependantController = 
          ControllerContext.Controller as IDependant;
        if (dependantController != null && dependantController.Resolver != null)
          serviceProvider = new ResolverServiceProviderWrapper
                            (dependantController.Resolver);
        else
          serviceProvider = ControllerContext.Controller as IServiceProvider;
        return serviceProvider;
      }
    }
