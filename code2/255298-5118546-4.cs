    public class MyClass
    {
        public static bool IsNull(MyClass other)
        { return ReferenceEquals(other, null); }
        public static bool HasValue(MyClass other)
        { return !IsNull(other); }
        // other code
    }
    public static class MyClassExtension
    {
       public static bool IsNull(this MyClass myClass)
       {
           return MyClass.IsNull(myClass);
       }
    }
