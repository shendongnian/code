    class Program
    {
      static void Main(string[] args)
      {
        try
        {
          var myMessage = new object();
          Action<dynamic> action = (dynamic h) => { h.Handle(myMessage); };
          Type myType = typeof(int);
          var method = typeof(Program).GetMethod("DoSomething");
          var concreteMethod = method.MakeGenericMethod(myType);
          concreteMethod.Invoke(null, new [] { action });
          Console.ReadKey();
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine(ex);
          Console.ReadKey();
        }
      }
      static public void DoSomething<T>(Action<dynamic> action)
      {
        Console.WriteLine("DoSomething invoked with T = " + typeof(T).FullName);
      }
    }
