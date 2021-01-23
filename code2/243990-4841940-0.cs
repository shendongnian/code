    // CS0053.cs
    class MyClass //defaults to private accessibility
    // try the following line instead
    // public class MyClass
    {
    }
    
    public class MyClass2
    {
       public MyClass myProperty   // CS0053
       {
          get
          {
             return new MyClass();
          }
          set
          {
          }
       }
    }
    
    public class MyClass3
    {
       public static void Main()
       {
       }
    }
