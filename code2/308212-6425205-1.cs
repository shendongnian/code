    public class A
    {
        public string Name { get; set; }
        public B B { get; set; }
    }
    
    public class B
    {
        public string Category { get; set; }
        public A A { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var result = Visit(typeof(A));
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }
    
        public static IEnumerable<PropertyInfo> Visit(Type t)
        {
            var visitedTypes = new HashSet<Type>();
            var result = new List<PropertyInfo>();
            InternalVisit(t, visitedTypes, result);
            return result;
        }
    
        private void InternalVisit(Type t, HashSet<Type> visitedTypes, IList<PropertyInfo> result)
        {
            if (visitedTypes.Contains(t))
            {
                return;
            }
    
            if (!IsPrimitive(t))
            {
                visitedTypes.Add(t);
                foreach (var property in t.GetProperties())
                {
                    if (IsPrimitive(property.PropertyType))
                    {
                        result.Add(property);
                    }
                    InternalVisit(property.PropertyType, visitedTypes, result);
                }
            }
        }
    
        private static bool IsPrimitive(Type t)
        {
            // TODO: put any type here that you consider as primitive as I didn't
            // quite understand what your definition of primitive type is
            return new[] { 
                typeof(string), 
                typeof(char),
                typeof(byte),
                typeof(sbyte),
                typeof(ushort),
                typeof(short),
                typeof(uint),
                typeof(int),
                typeof(ulong),
                typeof(long),
                typeof(float),
                typeof(double),
                typeof(decimal),
                typeof(DateTime),
            }.Contains(t);
        }
    }
