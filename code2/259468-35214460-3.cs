> public override IEnumerable<ModelValidationResult> Validate(object container)
{
    // Per the WCF RIA Services team, instance can never be null (if you have
    // no parent, you pass yourself for the "instance" parameter).
    string memberName = Metadata.PropertyName ?? Metadata.ModelType.Name;
    ValidationContext context = new ValidationContext(container ?? Metadata.Model)
    {
        DisplayName = Metadata.GetDisplayName(),
        MemberName = memberName
    };</code>
    #if !THERE_IS_A_BETTER_EXTENSION_POINT
       if(_shouldHotwireValidationContextServiceProviderToDependencyResolver 
           && Attribute.RequiresValidationContext)
           context.InitializeServiceProvider(DependencyResolver.Current.GetService);
    #endif
> 
> 
>        ValidationResult result = Attribute.GetValidationResult(Metadata.Model, context);
        if (result != ValidationResult.Success)
        {
            // ModelValidationResult.MemberName is used by invoking validators (such as ModelValidator) to
            // construct the ModelKey for ModelStateDictionary. When validating at type level we want to append the
            // returned MemberNames if specified (e.g. person.Address.FirstName). For property validation, the
            // ModelKey can be constructed using the ModelMetadata and we should ignore MemberName (we don't want
            // (person.Name.Name). However the invoking validator does not have a way to distinguish between these two
            // cases. Consequently we'll only set MemberName if this validation returns a MemberName that is different
            // from the property being validated.
                 
>            string errorMemberName = result.MemberNames.FirstOrDefault();
            if (String.Equals(errorMemberName, memberName, StringComparison.Ordinal))
            {
                errorMemberName = null;
            }
                
>            var validationResult = new ModelValidationResult
            {
                Message = result.ErrorMessage,
                MemberName = errorMemberName
            };
                
>            return new ModelValidationResult[] { validationResult };
        }
            
>        return Enumerable.Empty<ModelValidationResult>();
    }
#4. Tell MVC about the new `DataAnnotationsModelValidatorProvider` in town
after your Global.asax does `DependencyResolver.SetResolver(new AutofacDependencyResolver(container))` :-
    DataAnnotationsModelValidatorProvider.RegisterAdapterFactory(
        typeof(ValidatorServiceAttribute),
        (metadata, context, attribute) => new DataAnnotationsModelValidatorEx(metadata, context, attribute, true));
#5. Use your imagination to <strike>abuse your new Service Locator</strike> consume using ctor injection via `GetService` in your `ValidationAttribute`, for example:
    public class ValidatorServiceAttribute : ValidationAttribute
    {
        readonly Type _serviceType;
        public ValidatorServiceAttribute(Type serviceType)
        {
            _serviceType = serviceType;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validator = CreateValidatorService(validationContext);
            var resultOrValidationResultEmpty = validator.Validate(validationContext.ObjectInstance, value);
            if (resultOrValidationResultEmpty == ValidationResult.Success)
                return resultOrValidationResultEmpty;
            if (resultOrValidationResultEmpty.ErrorMessage == string.Empty)
                return new ValidationResult(ErrorMessage);
            return resultOrValidationResultEmpty;
        }
        IModelValidator CreateValidatorService(ValidationContext validationContext)
        {
            return (IModelValidator)validationContext.GetService(_serviceType);
        }
    }
Allows you to slap it on your model:- 
    class MyModel 
    {
        ...
        [Required, StringLength(42)]
        [ValidatorService(typeof(MyDiDependentValidator), ErrorMessage = "It's simply unacceptable")]
        public string MyProperty { get; set; }
        ....
    }
which wires it to a:
    public class MyDiDependentValidator : Validator<MyModel>
    {
        readonly IUnitOfWork _iLoveWrappingStuff;
        public MyDiDependentValidator(IUnitOfWork iLoveWrappingStuff)
        {
            _iLoveWrappingStuff = iLoveWrappingStuff;
        }
        protected override bool IsValid(MyModel instance, object value)
        {
            var attempted = (string)value;
            return _iLoveWrappingStuff.SaysCanHazCheez(instance, attempted);
        }
    }
The preceding two are connected by:
    interface IModelValidator
    {
        ValidationResult Validate(object instance, object value);
    }
    public abstract class Validator<T> : IModelValidator
    {
        protected virtual bool IsValid(T instance, object value)
        {
            throw new NotImplementedException("TODO: implement bool IsValid(T instance, object value) or ValidationResult Validate(T instance, object value)");
        }
        protected virtual ValidationResult Validate(T instance, object value)
        {
            return IsValid(instance, value) ? ValidationResult.Success : new ValidationResult("");
        }
        ValidationResult IModelValidator.Validate(object instance, object value)
        {
            return Validate((T)instance, value);
        }
    }
 
**I'm open to corrections, but most of all, ASP.NET team, would you be open to a PR to add a constructor with this facility to `DataAnnotationsModelValidator`?**
