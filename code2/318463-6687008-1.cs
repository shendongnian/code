    class Difference
    {
        private Difference(string propertyPath, object value1, object value2)
        {
            PropertyPath = propertyPath;
            Value1 = value1;
            Value2 = value2;
        }
        public string PropertyPath { get; private set; }
        public object Value1 { get; private set; }
        public object Value2 { get; private set; }
        public Difference Extend(string propertyName)
        {
            return new Difference(
                string.Format("{0}.{1}", propertyName, PropertyPath), Value1, Value2);
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}", PropertyPath, Value1, Value2);
        }
        public static IEnumerable<Difference> GetDifferences<T>(T value1, T value2)
        {
            return GetDifferences(typeof(T), value1, value2);
        }
        // types in this collection are compared directly
        // and not recursively using their properties
        private static readonly Type[] PrimitiveTypes =
            new[] { typeof(int), typeof(string), typeof(DateTime) };
        public static IEnumerable<Difference> GetDifferences(
            Type type, object obj1, object obj2)
        {
            foreach (var property in
                type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                var val1 = property.GetValue(obj1, null);
                var val2 = property.GetValue(obj2, null);
                if (PrimitiveTypes.Contains(property.PropertyType))
                {
                    if (!val1.Equals(val2))
                        yield return new Difference(property.Name, val1, val2);
                }
                else
                {
                    foreach (var difference in
                        GetDifferences(property.PropertyType, val1, val2))
                        yield return difference.Extend(property.Name);
                }
            }
        }
    }
