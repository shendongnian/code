    public class UseCaseRegistrationConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (type.IsAbstract || type.IsInterface || type.IsEnum)
                return;
            var useCaseInterface = type.GetInterface("IUseCase");
            if (useCaseInterface == null) 
                return;
            var constructor = type.GetConstructors().FirstOrDefault(c => !c.GetParameters().Any());
            if (constructor != null)
            {
                registry.For(useCaseInterface).Add(c => constructor.Invoke(new object[0]));
            }
        }
    }
