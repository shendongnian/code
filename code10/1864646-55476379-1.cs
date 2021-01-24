    public static class ChainConfigurator
    {
        public static IChainConfigurator<T> Chain<T>(this IServiceCollection services) where T : class
        {
            return new ChainConfiguratorImpl<T>(services);
        }
        public interface IChainConfigurator<T>
        {
            IChainConfigurator<T> Add<TImplementation>() where TImplementation : T;
            void Configure();
        }
        private class ChainConfiguratorImpl<T> : IChainConfigurator<T> where T : class
        {
            private readonly IServiceCollection _services;
            private List<Type> _types;
            private Type _interfaceType;
            public ChainConfiguratorImpl(IServiceCollection services)
            {
                _services = services;
                _types = new List<Type>();
                _interfaceType = typeof(T);
            }
            public IChainConfigurator<T> Add<TImplementation>() where TImplementation : T
            {
                var type = typeof(TImplementation);
                if (!_interfaceType.IsAssignableFrom(type))
                    throw new ArgumentException($"{type.Name} type is not an implementation of {_interfaceType.Name}", nameof(type));
                _types.Add(type);
                return this;
            }
            public void Configure()
            {
                if (_types.Count == 0)
                    throw new InvalidOperationException($"No implementation defined for {_interfaceType.Name}");
                bool first = true;
                foreach (var type in _types)
                {
                    ConfigureType(type, first);
                    first = false;
                }
            }
            private void ConfigureType(Type currentType, bool first)
            {
                var nextType = _types.SkipWhile(x => x != currentType).SkipWhile(x => x == currentType).FirstOrDefault();
                var ctor = currentType.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();
                var parameter = Expression.Parameter(typeof(IServiceProvider), "x");
                var ctorParameters = ctor.GetParameters().Select(x =>
                {
                    if (_interfaceType.IsAssignableFrom(x.ParameterType))
                    {
                        if (nextType == null)
                            return Expression.Constant(null, _interfaceType);
                        else
                            return Expression.Call(typeof(ServiceProviderServiceExtensions), "GetRequiredService", new Type[] { nextType }, parameter);
                    }
                    return (Expression)Expression.Call(typeof(ServiceProviderServiceExtensions), "GetRequiredService", new Type[] { x.ParameterType }, parameter);
                });
                var body = Expression.New(ctor, ctorParameters.ToArray());
                var resolveType= first ? _interfaceType : currentType;
                var expressionType = Expression.GetFuncType(typeof(IServiceProvider), resolveType);
                var expression = Expression.Lambda(expressionType, body, parameter);
                Func<IServiceProvider, object> x = (Func<IServiceProvider, object>)expression.Compile();
                _services.AddTransient(resolveType, x);
            }
        }
    }
