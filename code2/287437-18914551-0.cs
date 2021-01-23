    public struct ScopedName<T>
    {
        private const string Separator = "|";
        private readonly string _name;
        private readonly string _registrationName;
        public ScopedName(string name)
            : this()
        {
            _name = name;
            _registrationName = name + Separator + typeof(T).FullName;
        }
        public static implicit operator string(ScopedName<T> scopedName)
        {
            return scopedName._registrationName;
        }
        public bool IsMatach(string other)
        {
            if (string.IsNullOrWhiteSpace(other))
            {
                return false;
            }
            var i = other.IndexOf(Separator, StringComparison.InvariantCulture);
            if (i < 0)
            {
                return false;
            }
            return string.Equals(_name, other.Substring(0, i), StringComparison.InvariantCulture);
        }
    }
    public static class UnityEx 
    {
        public static IUnityContainer RegisterType<TFrom, TTo>(
            this IUnityContainer container,
            ScopedName<TTo> scopedName,
            LifetimeManager lifetimeManager,
            params InjectionMember[] injectionMembers) where TTo : TFrom
        {
            return container.RegisterType(typeof(TFrom), typeof(TTo), scopedName, lifetimeManager, injectionMembers);
        }
        public static IEnumerable<T> ResolveAll<T>(this IUnityContainer container, ScopedName<T> name, params ResolverOverride[] resolverOverrides)
        {
            var matches = container.Registrations.Where(r => name.IsMatach(r.Name));
            foreach (var registration in matches)
            {
                yield return container.Resolve<T>(registration.Name, resolverOverrides);
            }
        }
    }
