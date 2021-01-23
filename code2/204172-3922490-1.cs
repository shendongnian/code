    public class SomeType {
       private static readonly object Lock = new object();
       public void Foo() {
          lock (Lock) {
             Console.WriteLine("in foo");
             GC.Collect(2);
             GC.WaitForPendingFinalizers();
             GC.Collect(2);
          }
       }
      
       ~SomeType() {
          lock (Lock) {
             Console.WriteLine("in finalizer");
          }
       }
    }
