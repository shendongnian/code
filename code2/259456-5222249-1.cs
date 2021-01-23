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
        //nigh-on verbatim from the base class (check this in future versions of 
        //MVC) except I've changed how the ValidationContext is created
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
      /// <summary>
      /// Called by the Validate method to create the ValidationContext
      /// </summary>
      /// <param name="container"></param>
      /// <returns></returns>
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
      /// <summary>
      /// Called by the CreateValidationContext method to create an
      /// IServiceProvider instance to be passed to the ValidationContext.
      /// </summary>
      /// <param name="container"></param>
      /// <returns></returns>
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
