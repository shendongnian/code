    namespace Scratchpad
    {
        public static class TypeExtractor
        {
            public static IEnumerable<Type> ExtractTypes(this Type owner, HashSet<Type> visited = null)
            {
                if (visited == null)
                    visited = new HashSet<Type>();
    
                if (visited.Contains(owner))
                    return new Type[0];
    
                visited.Add(owner);
    
                switch (Type.GetTypeCode(owner))
                {
                    case TypeCode.Object:
                        break;
                    case TypeCode.Empty:
                        return new Type[0];
                    default:
                        return new[] {owner};
                }
    
                return
                    owner.GetMembers(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance |
                                     BindingFlags.Static |
                                     BindingFlags.FlattenHierarchy)
                        .SelectMany(x => x.ExtractTypes(visited)).Union(new[] {owner}).Distinct();
            }
    
            public static IEnumerable<Type> ExtractTypes(this MemberInfo member, HashSet<Type> visited)
            {
                switch (member.MemberType)
                {
                    case MemberTypes.Property:
                        return ((PropertyInfo) member).PropertyType.ExtractTypes(visited);
                        break;
                    case MemberTypes.Field:
                        return ((FieldInfo) member).FieldType.ExtractTypes(visited);
                    default:
                        return new Type[0];
                }
            }
        }
    
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
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var q = typeof (A).ExtractTypes();
                foreach (var type in q)
                {
                    Console.Out.WriteLine(type.Name);
                }
            }
        }
    }
