    // CS0053.cs
    class MyClass
    // try the following line instead
    // public class MyClass
    {
    }
    
        public class MyClass2
        {
           public MyClass MyProperty   // CS0053
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
