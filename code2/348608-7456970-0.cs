    public class A : IDisposable
    {
       int i = 100;
       bool disposed = false;
       public void Dispose()
       {
          disposed = true;
          Console.WriteLine("Dispose() called");
       }
       public void f()
       {
          if(disposed)
            throw new ObjectDisposedException();
    
          Console.WriteLine("{0}", i); i  *= 2;
       }
    }
