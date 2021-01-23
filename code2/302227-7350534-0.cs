    public static void Main()
    {
      try
      {
        AsyncContext.Run(() => myobj.DoSomething(null));
      }
      catch (Exception ex)
      {
        Console.Error.WriteLine(ex.Message);
      }
      Console.Write("done");
    }
    public async void DoSomething(string p)
    {
      if (p==null) throw new InvalidOperationException();
      else await SomeAsyncMethod();
    }
