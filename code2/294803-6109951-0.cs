    static class DecoratorUnityExtensions
    {
        public static void RegisterDecoratorChain<T>(this IUnityContainer container, Type[] decoratorChain)
        {
            Type parent = null;
            string parentName = null;
            foreach (Type t in decoratorChain)
            {
                string namedInstance = Guid.NewGuid().ToString();
                if (parent == null)
                {
                    // top level, just do an ordinary register type                    
                    container.RegisterType(typeof(T), t, namedInstance);
                }
                else
                {
                    // could be cleverer here. Just take first constructor
                    var constructor = t.GetConstructors()[0];
                    var resolvedParameters = new List<ResolvedParameter>();
                    foreach (var constructorParam in constructor.GetParameters())
                    {
                        if (constructorParam.ParameterType == typeof(T))
                        {
                            resolvedParameters.Add(new ResolvedParameter<T>(parentName));
                        }
                        else
                        {
                            resolvedParameters.Add(new ResolvedParameter(constructorParam.ParameterType));
                        }
                    }
                    if (t == decoratorChain.Last())
                    {
                        // not a named instance
                        container.RegisterType(typeof(T), t, new InjectionConstructor(resolvedParameters.ToArray()));
                    }
                    else
                    {
                        container.RegisterType(typeof(T), t, namedInstance, new InjectionConstructor(resolvedParameters.ToArray()));
                    }
                }
                parent = t;
                parentName = namedInstance;
            }
        }
    }
