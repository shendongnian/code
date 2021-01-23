    static class Initializer
    {
        private static Dictionary<PropertyInfo, Action<object>> setterCache = new Dictionary<PropertyInfo, Action<object>>();
        public static void Init(object obj)
        {
            Type t = obj.GetType();
            var props = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var propertyInfo in props)
            {
                var attr = (DefaultAttribute) propertyInfo.GetCustomAttributes(typeof (DefaultAttribute), true).FirstOrDefault();
                if (attr == null)
                    return;
                var setter = propertyInfo.GetSetMethod();
                if (setter == null) continue;
                // we have to create expression like (object obj) => setter((T)obj) where T is the type of property
                var param = Expression.Parameter(typeof (object), "obj");
                Action<object> set;
                if (!setterCache.TryGetValue(propertyInfo, out set))
                {
                    var expr = Expression.Lambda(
                        Expression.Call(Expression.Constant(obj),
                                        setter,
                                        Expression.Convert(param, propertyInfo.PropertyType)),
                        param);
                    set = (Action<object>) (expr.Compile());
                }
                set(attr.DefaultValue);
            }
        }
    }
