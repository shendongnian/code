    public interface IValidationService
    {
        IEnumerable<ValidationError> Validate<T>(T entity)
            where T : class;
    }
    
    public class FluentValidationService : IValidationService
    {
        private readonly IValidatorFactory validatorFactory;
        
        public FluentValidationService(IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;
        }
    
        public IEnumerable<ValidationError> Validate<T>(T entity)
            where T : class
        {
            var validator = this.validatorFactory.GetValidator<T>();
            var result = validator.Validate(entity);
            return result.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage));
        }
    }
    
    // Then implement FV's IValidatorFactory:
    
    public class NinjectValidatorFactory : ValidatorFactoryBase
    {
        private readonly IKernel kernel;
    
        public NinjectValidatorFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }
    
        public override IValidator CreateInstance(Type validatorType)
        {
            return kernel.TryGet(validatorType) as IValidator;
        }
    }
    
    // I then wire both of these in a Ninject Module:
    
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IValidationService>().To<FluentValidationService>().InRequestScope(); // Specific to MVC.
            this.Bind<IValidatorFactory>().To<NinjectValidatorFactory>().InRequestScope();
        }
    }
    
    // Then I can use it inside a service:
    
    public class FooService
    {
        private readonly IValidationService validationService;
        
        public FooService(IValidationService validationService)
        {
            this.validationService = validationService;
        }
        
        public bool Add(Foo foo)
        {
            if(this.validationService.Validate(foo).Any())
            {
                // Handle validation errors..
            }
            
            // do other implementation details here.
        }
    }
