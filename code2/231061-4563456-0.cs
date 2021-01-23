    class Generic<T> { }
    class Derived<T> : Generic<T> { }
    class NonDerived<T> { }
    class Program
    {
        static bool IsDerivedFromGenericT(Type type)
        {
            if (!type.IsGenericType)
                return false;
            if (type.GetGenericTypeDefinition() == typeof(Generic<>))
                return true;
            if (type.BaseType == null)
                return false;
            return IsDerivedFromGenericT(type.BaseType);
        }
        static void Main(string[] args)
        {
            var b1 = IsDerivedFromGenericT(new Derived<int>().GetType()); // true
            var b2 = IsDerivedFromGenericT(new Derived<string>().GetType()); // true
            var b3 = IsDerivedFromGenericT(new NonDerived<string>().GetType()); // false
        }
    }
