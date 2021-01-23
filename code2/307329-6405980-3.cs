    static class Initializer
    {
        private static Dictionary<PropertyInfo, Action<object>> setterCache = new Dictionary<PropertyInfo, Action<object>>();
        public static void Init(object obj)
        {
            foreach (var propertyInfo in obj.GetType().GetProperties())
            {
                var attr = (DefaultAttribute) propertyInfo.GetCustomAttributes(typeof (DefaultAttribute), true).FirstOrDefault();
                if (attr == null) return;
                var setter = propertyInfo.GetSetMethod();
                if (setter == null) continue;
                Action<object> set;
                if (!setterCache.TryGetValue(propertyInfo, out set))
                {
                    // we have to create expression like value => obj.setter((T)value)
                    // where T is the type of property and obj is instance being initialized
                    var param = Expression.Parameter(typeof(object), "obj");
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
