    public static class UnityExtensions
    {
        public static IUnityContainer Decorate<TInterface, TBase, TDecorator>(this IUnityContainer container, params InjectionMember[] injectionMembers)
            where TBase : TInterface
            where TDecorator : class, TInterface
        {
            return Decorate<TInterface, TBase, TDecorator>(container, null, injectionMembers);
        }
        public static IUnityContainer Decorate<TInterface, TBase, TDecorator>(this IUnityContainer container, LifetimeManager lifetimeManager, params InjectionMember[] injectionMembers)
            where TBase : TInterface
            where TDecorator : class, TInterface
        {
            string uniqueId = Guid.NewGuid().ToString();
            if (lifetimeManager != null)
            {
                container.RegisterType<TInterface, TDecorator>(uniqueId, lifetimeManager, injectionMembers);
            }
            else
            {
                container.RegisterType<TInterface, TDecorator>(uniqueId, injectionMembers);
            }
            container.RegisterType<TInterface, TDecorator>(new InjectionFactory((c, t, sName) =>
            {
                var baseObj = container.Resolve<TBase>();
                return c.Resolve<TDecorator>(uniqueId, new DependencyOverride<TInterface>(baseObj));
            }));
            return container;
        }
    }
