    class Container
    {
        class Registration
        {
            public Type RegistrationType;
            public Func<Container, object> Resolver;
        }
        List<Registration> registrations = new List<Registration>();
        public object Resolve(Type type)
        {
            return registrations
                .First(r => type.IsAssignableFrom(r.RegistrationType))
                .Resolver(this);
        }
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }
        public void Register<T>(Func<Container, T> registration) where T : class
        {
            registrations.Add(new Registration()
            {
                RegistrationType = typeof(T),
                Resolver = registration
            });
        }
    }
