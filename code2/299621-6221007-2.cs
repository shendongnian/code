    public class MissingValidatorResolver : NinjectComponent, IMissingBindingResolver
    {
        public IEnumerable<IBinding> Resolve(
            Multimap<Type, IBinding> bindings, IRequest request)
        {
            var service = request.Service;
            if (!typeof(IValidator).IsAssignableFrom(service))
            {
                return Enumerable.Empty<IBinding>();
            }
            var type = service.GetGenericArguments()[0];
            var validatorType = typeof(NullValidator<>).MakeGenericType(type);
            var binding = new Binding(service)
            {
                ProviderCallback = StandardProvider.GetCreationCallback(validatorType)
            };
            return new[] { binding };
        }
    }
