    public class NamedFooRegistrationSource : IRegistrationSource
    {
        public bool IsAdapterForIndividualComponents => false;
        public IEnumerable<IComponentRegistration> RegistrationsFor(
            Service service,
            Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            KeyedService keyedService = service as KeyedService;
            if (keyedService == null || keyedService.ServiceKey.GetType() != typeof(String))
            {
                yield break;
            }
            IComponentRegistration registration = RegistrationBuilder
                .ForDelegate(keyedService.ServiceType, (c, p) =>
                {
                    Type foosType = typeof(IEnumerable<>).MakeGenericType(keyedService.ServiceType);
                    IEnumerable<IFoo> foos = (IEnumerable<IFoo>)c.Resolve(foosType);
                    foos = foos.Where(f => f.AutoFactName == (String)keyedService.ServiceKey).ToArray();
                    if (foos.Count() == 0)
                    {
                        throw new Exception($"no Foo available for {keyedService.ServiceKey}");
                    }
                    else if (foos.Count() > 1)
                    {
                        throw new Exception($"more than 1 Foo available for {keyedService.ServiceKey}");
                    }
                    else
                    {
                        return foos.First();
                    }
                })
                .Named((String)keyedService.ServiceKey, keyedService.ServiceType)
                .CreateRegistration();
            yield return registration;
        }
    }
