    public class MyClass : IDisposable
    {
       //since MyClass implements IDisposable, it must contain a Dispose() method otherwise will compile error
       public void Dispose()
       {
          // do something
       }
    }
