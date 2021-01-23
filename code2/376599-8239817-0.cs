    [CLSCompliant(false)]
    public class MyRegistration : IRegistrationConvention
    /// <inheritdoc />
        public void Process(Type type, Registry registry)
        {           
            Type interfaceType = type.GetInterface(typeof(IFoo).Name);
            if (interfaceType == null)
            {
                return;
            }
            registry.AddType(interfaceType, type, type.Name);
            // Do your stuff with INewFoo
        }
    }
