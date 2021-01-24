 c#
public interface IValidator<T>
{
    IEnumerable<string> Validate(T instance);
}
On top of this abstraction, you can define as many implementations as you will, for instance one (or more) for validating `MyViewmodel`:
 c#
public class MyViewmodelValidator : IValidator<MyViewmodel>
{
    private readonly IMyService service;
    public MyViewmodelValidator(IMyService service) => this.service = service;
    public IEnumerable<string> Validate(MyViewmodel instance)
    {
        yield return "I'm not valid.";
    }
}
This is all the application code you need to get things in motion. Of course you should model the `IValidator<T>` interface according to your application needs.
Only thing left is ensure MVC uses these validators when validating your view models. This can be done with a custom `IModelValidatorProvider` implementation:
 c#
class SimpleInjectorModelValidatorProvider : IModelValidatorProvider
{
    private readonly Container container;
    public SimpleInjectorModelValidatorProvider(Container container) =>
        this.container = container;
    public void CreateValidators(ModelValidatorProviderContext ctx)
    {
        var validatorType =
            typeof(ModelValidator<>).MakeGenericType(ctx.ModelMetadata.ModelType);
        var validator = (IModelValidator)this.container.GetInstance(validatorType);
        ctx.Results.Add(new ValidatorItem { Validator = validator });
    }
}
// Adapter that translates calls from IModelValidator into the IValidator<T>
// application abstraction.
class ModelValidator<TModel> : IModelValidator
{
    private readonly IEnumerable<IValidator<TModel>> validators;
    public ModelValidator(IEnumerable<IValidator<TModel>> validators) =>
        this.validators = validators;
    public IEnumerable<ModelValidationResult> Validate(ModelValidationContext ctx) =>
        this.Validate((TModel)ctx.Model);
    private IEnumerable<ModelValidationResult> Validate(TModel model) =>
        from validator in this.validators
        from errorMessage in validator.Validate(model)
        select new ModelValidationResult(string.Empty, errorMessage);
}
The only thing left to do is add `SimpleInjectorModelValidatorProvider` to the MVC pipeline and make the required registrations:
 c#
services.AddMvc(options =>
    {
        options.ModelValidatorProviders.Add(
            new SimpleInjectorModelValidatorProvider(container));
    });
// Register ModelValidator<TModel> adapter class
container.Register(typeof(ModelValidator<>), typeof(ModelValidator<>),
    Lifestyle.Singleton);
// Auto-register all validator implementations
container.Collection.Register(
    typeof(IValidator<>), typeof(MyViewmodelValidator).Assembly);
Et voila! There you have it—a completely loosely coupled validation structure that can be defined according to the needs of your application, while using best practices like Constructor Injection and allows your validation code to be fully tested without having to resort to anti-patterns, and without being tightly coupled with the MVC infrastructure.
  [1]: https://freecontent.manning.com/the-service-locator-anti-pattern/
