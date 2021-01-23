    internal interface IFoo
    {
      void foo();
    }
    
    public class A : IFoo
    {
      void IFoo.foo()
      {
        Console.WriteLine("A");
      }
    }
