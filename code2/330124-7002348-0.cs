    public static class TypeExtensions
    {
        public static bool IsNotTypeOf<T, X>(this T instance, X typeInstance)
        {
            return instance.GetType() != typeInstance.GetType();
        }
    }
    // ...
    if(e.parameter.IsNotTypeOf(MyClass)) { /* do something */ } ;
