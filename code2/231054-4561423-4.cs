        public class GenericClass<T>
        {
        }
        public class GenericClassInherited<T> : GenericClass<T>
        {
        }
        public static bool IsDeriveFrom(object o)
        {
            return o.GetType().BaseType.GetGenericTypeDefinition() == typeof(GenericClass<>);
        }
