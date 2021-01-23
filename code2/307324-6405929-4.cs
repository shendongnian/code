    public static class DefaultValueHelper
    {
        private static readonly Dictionary<Type, Action<object>> _initializerCache;
    
        static DefaultValueHelper()
        {
            _initializerCache = new Dictionary<Type, Action<object>>();
        }
    
        public static void InitializeDefaultValues(object obj)
        {
            if (obj == null)
                return;
            
            var type = obj.GetType();
            Action<object> initializer;
            if (!_initializerCache.TryGetValue(type, out initializer))
            {
                initializer = MakeInitializer(type);
                _initializerCache[type] = initializer;
            }
            initializer(obj);
        }
        
        private static Action<object> MakeInitializer(Type type)
        {
            var arg = Expression.Parameter(typeof(object), "arg");
            var variable = Expression.Variable(type, "x");
            var cast = Expression.Assign(variable, Expression.Convert(arg, type));
            var assignments =
                from prop in type.GetProperties()
                let attr = GetDefaultValueAttribute(prop)
                where attr != null
                select Expression.Assign(Expression.Property(variable, prop), Expression.Constant(attr.Value));
            
            var body = Expression.Block(
                new ParameterExpression[] { variable },
                new Expression[] { cast }.Concat(assignments));
            var expr = Expression.Lambda<Action<object>>(body, arg);
            return expr.Compile();
        }
        
        private static DefaultValueAttribute GetDefaultValueAttribute(PropertyInfo prop)
        {
            return prop.GetCustomAttributes(typeof(DefaultValueAttribute), true)
                       .Cast<DefaultValueAttribute>()
                       .FirstOrDefault();
        }
    }
