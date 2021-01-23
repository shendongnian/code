        static class TypeBuilderExtension
        {
            private static Dictionary<TypeBuilder, ConstructorBuilder> _cache = new Dictionary<TypeBuilder, ConstructorBuilder>();
    
            public static ConstructorBuilder DefineMyConstructor(this TypeBuilder tb)
            {
                if (!_cache.ContainsKey(tb))
                {
                    _cache.Add(tb, tb.DefineConstructor(MethodAttributes.Public, CallingConventions.HasThis, new Type[0]));
                }
    
                return _cache[tb];
            }
        }
