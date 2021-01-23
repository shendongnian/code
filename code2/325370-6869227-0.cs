    public static class TypeHelper
    {
        public static IEnumerable<Type> GetTypeCombination(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(T<,>))
                return type.GetGenericArguments().SelectMany(GetTypeCombination);
            return new Type[] { type };
        }
    }
    public class T<T1, T2>
    {
        public static IEnumerable<Type> GetTypeCombination()
        {
            return typeof(T1).GetTypeCombination()
                .Concat(typeof(T2).GetTypeCombination());
        }
    }
