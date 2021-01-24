    public static class Extensions
    {
        public static int NumbeofArays<TClass>(this TClass entry) where TClass : class, new()
        {
            Type type = typeof(TClass);
            int arrays = 0;
            foreach (var propertyInfo in type.GetProperties())
            {
                if (propertyInfo.PropertyType.IsArray)
                    arrays = arrays + 1;
            }
            return arrays;
        }
    }
