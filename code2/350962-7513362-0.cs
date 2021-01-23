    internal interface IFoo
    {
      void foo();
    }
    
    public class A : IFoo
    {
      public void IFoo.foo()
      {
        Console.WriteLine("A");
      }
    }
