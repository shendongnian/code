    class ObjectFiller<T>
    {
        private static Func<IDictionary<string, object>, T> FillerDelegate;
        private static void Init()
        {
            var obj = Expression.Parameter(typeof(T), "obj");
            var valuesDictionary = Expression.Parameter(typeof(IDictionary<string, object>), "values");
            var create = Expression.Assign(
                obj, Expression.Call(typeof(Activator), "CreateInstance", new[] { typeof(T) }));
            var properties = typeof(T).GetProperties();
            var setters = Expression.Block(properties.Select(p => CreateSetter(p, obj, valuesDictionary)));
            var methodBody = Expression.Block(typeof(T), new[] { obj }, create, setters, obj);
            var fillerExpression = Expression.Lambda<Func<IDictionary<string, object>, T>>(methodBody, valuesDictionary);
            FillerDelegate = fillerExpression.Compile();
        }
        static Expression CreateSetter(PropertyInfo property, Expression obj, Expression valuesDictionary)
        {
            var indexer = Expression.MakeIndex(
                valuesDictionary,
                typeof(IDictionary<string, object>).GetProperty("Item", new[] { typeof(string) }),
                new[] { Expression.Constant(property.Name) });
            var setter = Expression.Assign(
                Expression.Property(obj, property),
                Expression.Convert(indexer, property.PropertyType));
            var valuesContainsProperty = Expression.Call(
                valuesDictionary, "ContainsKey", null, Expression.Constant(property.Name));
            var condition = Expression.IfThen(valuesContainsProperty, setter);
            return condition;
        }
        public T FillObject(IDictionary<string, object> values)
        {
            if (FillerDelegate == null)
                Init();
            return FillerDelegate(values);
        }
    }
