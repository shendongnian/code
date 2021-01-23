    public class BaseClass
    {
      public virtual void Method1()  //Virtual method
      {
        Console.WriteLine("Running BaseClass Method1");
      }
      public void Method2()  //Not a virtual method
      {
        Console.WriteLine("Running BaseClass Method2");
      }
    }
    public class InheritedClass : BaseClass
    {
      public override void Method1()  //Overriding the base virtual method.
      {
        Console.WriteLine("Running InheritedClass Method1");
      }
      public new void Method2()  //Can't override the base method; must 'new' it.
      {
        Console.WriteLine("Running InheritedClass Method2");
      }
    }
