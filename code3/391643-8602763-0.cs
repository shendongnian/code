    /// <summary>
    /// ClassExtensions
    /// </summary>
    static class ClassExtensions
    {
        /// <summary>
        /// Converts an object to nullable.
        /// </summary>
        /// <typeparam name="P">The object type</typeparam>
        /// <param name="s">The object value.</param>
        /// <returns></returns>
        public static Nullable<P> ToNullable<P>(this string s) where P : struct
        {
            Nullable<P> result = new Nullable<P>();
            try
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(P));
                    result = (P)conv.ConvertFrom(s);
                }
            }
            catch { }
            return result;
        }
        /// <summary>
        /// Converts a dictionary of property values into a class.
        /// </summary>
        /// <typeparam name="T">The class type.</typeparam>
        /// <param name="source">The properties dictionary.</param>
        /// <returns>An instance of T with property values set to the values defined in the dictionary.</returns>
        public static T ToClass<T>(this IDictionary<string, string> source) where T : class, new()
        {
            Type classType = typeof(T);
            T returnClass = new T();
            foreach (var keyValue in source)
            {
                PropertyInfo prop = classType.GetProperty(keyValue.Key);
                MethodInfo method = typeof(ClassExtensions).GetMethod("ToNullable");
                MethodInfo generic = method.MakeGenericMethod(prop.PropertyType);
                object convertedValue = generic.Invoke(keyValue.Value, new object[] { keyValue.Value });
                prop.SetValue(returnClass, convertedValue, null);
            }
            return returnClass;
        }
    }
    /// <summary>
    /// TestClass
    /// </summary>
    class TestClass
    {
        public int Property1 { get; set; }
        public long Property2 { get; set; }
    }
    /// <summary>
    /// Program.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<string, string> properties = new Dictionary<string, string> { { "Property1", "1" }, { "Property2", "2" } };
            properties.ToClass<TestClass>();
        }
    }
