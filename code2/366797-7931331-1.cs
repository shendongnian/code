    public static class MyConverter
    {
        private static Dictionary<Type, Func<object, object>> _MyConverter;
        static MyConverter()
        {
            _MyConverter = new Dictionary<Type, Func<object, object>>();
            // Use the Add() method to include a lambda with the proper signature.
            _MyConverter.Add(typeof(int), (source) => Convert.ToInt32 (source.ToString()));
            // Use the index operator to include a lambda with the proper signature.
            _MyConverter[typeof(double)] = (source) => Convert.ToDouble(source.ToString());
            
            // Use the Add() method to include a more complex lambda using curly braces.
            _MyConverter.Add(typeof(decimal), (source) =>
            {
                return Convert.ToDecimal(source.ToString());
            });
            
            // Use the index operator to include a function with the proper signature.
            _MyConverter[typeof(float)] = MySpecialConverterFunctionForFloat;
        }
        // A function that does some more complex conversion which is simply unreadable as lambda.
        private static object MySpecialConverterFunctionForFloat(object source)
        {
            var something = source as float?;
            if (something != null
                && something.HasValue)
            {
                return something.Value;
            }
            return 0;
        }
        public static TDestination As<TDestination>(this object source, TDestination defaultValue = default(TDestination))
        {
            // Do some parameter checking (if needed).
            if (source == null)
                throw new ArgumentNullException("source");
            // The fast-path exit.
            if (source.GetType().IsAssignableFrom(typeof(TDestination)))
                return (TDestination)source;
            Func<object, object> func;
            // Check if a converter is available.
            if (_MyConverter.TryGetValue(typeof(TDestination), out func))
            {
                // Call it and return the result.
                return (TDestination)func(source);
            }
            // Nothing found, so return the wished default.
            return defaultValue;
        }
    }
