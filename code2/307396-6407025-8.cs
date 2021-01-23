    public class TypeScanner<T> : IRegistrationConvention
    {
        private static readonly Type PluginInterface = typeof(T);
        
        public void Process(Type type, Registry registry)
        {
            if (type.IsAbstract || type.BaseType == null) return;
            if (PluginInterface.IsAssignableFrom(type) == false) return;
            registry.For(PluginInterface).Singleton().Add(instance);
        }
    }
