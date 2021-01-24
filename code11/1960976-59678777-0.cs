    public class ImmutableArrayRegistrationSource : IRegistrationSource
    {
        public bool IsAdapterForIndividualComponents => false;
        private static MethodInfo toImmutableArrayMethod =
                typeof(ImmutableArray)
                    .GetMethods()
                    .Where(m => m.Name == nameof(ImmutableArray.ToImmutableArray)
                                && m.GetParameters().Any(p => p.ParameterType.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                    .FirstOrDefault();
        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            IServiceWithType typedService = service as IServiceWithType;
            if (typedService != null && typedService.ServiceType.IsClosedTypeOf(typeof(ImmutableArray<>)))
            {
                Type elementType = typedService.ServiceType.GetGenericArguments()[0];
                IComponentRegistration r = RegistrationBuilder.ForDelegate(typedService.ServiceType, (c, p) =>
                {
                    Object elements = c.Resolve(typeof(IEnumerable<>).MakeGenericType(elementType));
                    Object immutableArray = toImmutableArrayMethod.MakeGenericMethod(elementType)
                                                                  .Invoke(null, new Object[] { elements });
                    return immutableArray;
                }).As(service)
                  .CreateRegistration();
                yield return r;
            }
            yield break;
        }
    }
