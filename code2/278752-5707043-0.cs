    public class SomeOtherClass
    {
         public void DoSomething(IMyInterface something)
         {
              something.MethodToImplement();
         }
    }
    public class Program
    {
         public static void Main(string[] args)
         {
              if(args != null)
                  new SomeOtherClass().DoSomething(new ImplementationOne());
              else
                  new SomeOtherClass().DoSomething(new ImplementationTwo());
         }
    }
