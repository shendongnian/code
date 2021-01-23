    public class ValidatorMissingBindingResolver : NinjectComponent, MissingBindingResolver
    {
        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, IRequest request)
        {
            Type service = request.Service;
            if (typeof(IValidator).IsAssignableFrom(service))
            {
                Type genericArgumentType = request.Service.GetGenericArguments()[0];
                Type nullValidatorType = typeof(NullValidator<>).MakeGenericType(genericArgumentType);
                var binding = new Binding(service);
                binding.ProviderCallback = StandardProvider.GetCreationCallback(nullValidatorType);
                return new[] { binding };
            }
            return Enumerable.Empty<IBinding>();
        }
    }
