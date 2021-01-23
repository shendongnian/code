    public class MyClass : IDisposable
    {
      public delegate int DoSomething();
    
      public int Zero() {return 0;}
      public int One() {return 1;}
    
      public void Dispose()
      {
        // Cleanup
      }
    }
    
    public class AnotherCLass
    {
        public static void UseMyClass(Converter<MyClass,int> func)
        {
          using (var mc = new MyClass())
          {
            // Call the delegate function
            func(mc);
          }
        }
    }
    AnotherClass.UseMyClass(
        (Converter<MyClass, int>)Delegate.CreateDelegate(
            typeof(Converter<MyClass, int>),
            typeof(MyClass).GetMethod("One")
        )
    );
