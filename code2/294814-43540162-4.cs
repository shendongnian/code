    public static class UnityExtensions
    {
        public static IUnityContainer Decorate<TInterface, TDecorator>(this IUnityContainer container, params InjectionMember[] injectionMembers)
            where TDecorator : class, TInterface
        {
            return Decorate<TInterface, TDecorator>(container, null, injectionMembers);
        }
        public static IUnityContainer Decorate<TInterface, TDecorator>(this IUnityContainer container, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
            where TDecorator : class, TInterface
        {
            string uniqueId = Guid.NewGuid().ToString();
            var existingRegistration = container.Registrations.LastOrDefault(r => r.RegisteredType == typeof(TInterface));
            if(existingRegistration == null)
            {
                throw new ArgumentException("No existing registration found for the type " + typeof(TInterface));
            }
            var existing = existingRegistration.MappedToType;
            //1. Create a wrapper. This is the actual resolution that will be used
            if (lifetimeManager != null)
            {
                container.RegisterType<TInterface, TDecorator>(uniqueId, lifetimeManager, injectionMembers);
            }
            else
            {
                container.RegisterType<TInterface, TDecorator>(uniqueId, injectionMembers);
            }
            //2. Unity comes here to resolve TInterface
            container.RegisterType<TInterface, TDecorator>(new InjectionFactory((c, t, sName) =>
            {
                //3. We get the decorated class instance TBase
                var baseObj = container.Resolve(existing);
                //4. We reference the wrapper TDecorator injecting TBase as TInterface to prevent stack overflow
                return c.Resolve<TDecorator>(uniqueId, new DependencyOverride<TInterface>(baseObj));
            }));
            return container;
        }
    }
