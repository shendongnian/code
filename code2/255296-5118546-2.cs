    public class MyClass
    {
       public static bool IsNull(MyClass myClass) { ... }
    }
    public static class MyClassExtension
    {
       public static bool IsNull(this MyClass myClass)
       {
           return MyClass.IsNull(myClass);
       }
    }
