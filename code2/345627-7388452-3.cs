    public class ServiceFactory
    {
        private static readonly Dictionary<RuntimeTypeHandle, Func<object>> _dtoMappings = new Dictionary<RuntimeTypeHandle, Func<object>>();
        public static IDocumentService<TDto> GetDocumentService<TDto>()
        {
            var rth = typeof(TDto).TypeHandle;
            Func<object> concreteFactory;
            lock (_dtoMappings)
            {
                if (_dtoMappings.TryGetValue(typeof(TDto).TypeHandle, out concreteFactory))
                    return (IDocumentService<TDto>)concreteFactory();
                FillMappings();
                if (!_dtoMappings.TryGetValue(typeof(TDto).TypeHandle, out concreteFactory))
                    throw new Exception("No concrete implementation found.");
                return (IDocumentService<TDto>)concreteFactory();
            }
        }
        private static void FillMappings()
        {
            // You would only need to change this method if you used the configuration-based approach.
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var attrs = assembly.GetCustomAttributes(typeof(DtoProviderAttribute), false);
                foreach (DtoProviderAttribute item in attrs)
                {
                    if (!_dtoMappings.ContainsKey(item.ProvidedType.TypeHandle))
                    {
                        var expr = Expression.Lambda<Func<object>>(Expression.Convert(Expression.New(item.ProviderType), typeof(object)));
                        _dtoMappings.Add(item.ProvidedType.TypeHandle, expr.Compile());
                    }
                }
            }
        }   
    }
