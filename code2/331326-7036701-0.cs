	ObjectFactory.Configure(cfg => cfg.AddRegistry(new MyRegistry()));
	ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
	
	//Configure FV to use StructureMap
	var factory = new StructureMapValidatorFactory();
	
	//Tell MVC to use FV for validation
	ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(factory));
	DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
	
	public class StructureMapValidatorFactory : ValidatorFactoryBase
	{
	public override IValidator CreateInstance(Type validatorType)
	{
	    return ObjectFactory.TryGetInstance(validatorType) as IValidator;
	}
	}
	
	
	public class MyRegistry : Registry
	{
	public MyRegistry()
	{
	    AssemblyScanner.FindValidatorsInAssemblyContaining<LiveReport.Domain.Validation.PersonValidator>()
	      .ForEach(result =>
	      {
	          For(result.InterfaceType)
	             .Singleton()
	             .Use(result.ValidatorType);
	      });
	
	}
	}
