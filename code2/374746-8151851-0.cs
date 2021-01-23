    using System;
    using System.Reflection;
    
    interface IFoo
    {
      void DoGood();
      void DoBad();
    }
    
    class Foo : MarshalByRefObject, IFoo
    {
      public void DoGood() { Console.WriteLine("I'm good (" + AppDomain.CurrentDomain.FriendlyName + ")"); }
      public void DoBad() { throw new Exception("I'm bad (" + AppDomain.CurrentDomain.FriendlyName + ")"); }
    }
    
    class Program
    {
      public static void Main()
      {
        try
        {
          AppDomain domain = AppDomain.CreateDomain("FooDomain");
          try
          {
            string assemblyName = Assembly.GetExecutingAssembly().FullName; // may be different assembly
            string typeName = "Foo";
            IFoo foo = (IFoo)domain.CreateInstanceAndUnwrap(assemblyName, typeName); 
            foo.DoGood();
            foo.DoBad();
          }
          finally
          {
            AppDomain.Unload(domain);
          }
        }
        catch (Exception e)
        {
          Console.WriteLine("Error: " + e.Message);
        }
      }
    }
