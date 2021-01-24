    public static class ClassHelper<TClass> where TClass : class, new()
    {
        static ClassHelper()
        {
            Type type = typeof(TClass);
            int arrays = 0;
            foreach (var propertyInfo in type.GetProperties())
            {
                if (propertyInfo.PropertyType.IsArray)
                    arrays = arrays + 1;
            }
            NumberofArrays = arrays;
        }
        public static int NumberofArrays { get; }
    }
