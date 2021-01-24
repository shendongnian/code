public class ValidatorFactory : ValidatorFactoryBase
{
    private readonly Container _container;
    public ValidatorFactory(Container container)
    {
        _container = container;
    }
    public override IValidator CreateInstance(Type validatorType)
    {
        if (_container.GetRegistration(validatorType) == null)
        {
            return null;
        }
        if (validatorType == typeof(IValidator<Task>))
        {
            return null;
        }
        return (IValidator)_container.GetInstance(validatorType);
    }
}
That will ensure that the lambda expression in the SetValidator call creates the TaskValidator directly, rather than via the validator factory.
