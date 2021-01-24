    public BaseController() {
        
    }
    
    public void ValidateFor<TValidator>(object instance) where TValidator : IValidator {
         // Access the service provider via the current request
         var validator = HttpContext.RequestServces.GetService<TValidator>();
    
          var result = validator.Validate(instance);
    
          if (result.IsValid) {
                return;
          }
    
          //... process errors
    }
