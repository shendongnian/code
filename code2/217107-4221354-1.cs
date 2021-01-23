     class Program
    {
        static void Main(string[] args)
        {
            var lines = ExtractHelper.IterateProps(typeof(Container)).ToArray();
            foreach (var line in lines)
                Console.WriteLine(line);
            Console.ReadLine();
        }
    }
    static class ExtractHelper
    {
        public static IEnumerable<string> IterateProps(Type baseType)
        {
            return IteratePropsInner(baseType, baseType.Name);
        }
        private static IEnumerable<string> IteratePropsInner(Type baseType, string baseName)
        {
            var props = baseType.GetProperties();
            foreach (var property in props)
            {
                var name = property.Name;
                var type = ListArgumentOrSelf(property.PropertyType);
                if (IsMarked(type))
                    foreach (var info in IteratePropsInner(type, name))
                        yield return string.Format("{0}.{1}", baseName, info);
                else
                    yield return string.Format("{0}.{1}", baseName, property.Name);
            }
        }
        static bool IsMarked(Type type)
        {
            return type.GetCustomAttributes(typeof(ExtractNameAttribute), true).Any();
        }
        public static Type ListArgumentOrSelf(Type type)
        {
            if (!type.IsGenericType)
                return type;
            if (type.GetGenericTypeDefinition() != typeof(List<>))
                throw new Exception("Only List<T> are allowed");
            return type.GetGenericArguments()[0];
        }
    }
    [ExtractName]
    public class Container
    {
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
    }
    [ExtractName]
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public List<Telephone> Telephones { get; set; }
    }
    [ExtractName]
    public class Telephone
    {
        public string CellPhone { get; set; }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = true, AllowMultiple = true)]
    public sealed class ExtractNameAttribute : Attribute
    { }
