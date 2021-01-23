    static void Main(string[] args)
    {
      Nito.AsyncEx.AsyncContext.Run(TestAsync);
      Console.WriteLine("Ready!");
      Console.ReadKey();
    }
