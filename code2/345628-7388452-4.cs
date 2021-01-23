        private static void FillMappings()
        {
            foreach (var type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => x.IsClass && !x.IsAbstract))
            {
                foreach (var iface in type.GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDocumentService<>)))
                {
                    var arg = iface.GetGenericArguments()[0];
                    if (!_dtoMappings.ContainsKey(arg.TypeHandle))
                    {
                        var expr = Expression.Lambda<Func<object>>(Expression.Convert(Expression.New(type), typeof(object)));
                        _dtoMappings.Add(arg.TypeHandle, expr.Compile());
                    }
                }
            }
        }
