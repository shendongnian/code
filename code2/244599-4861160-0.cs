    static void PrintHello()
    {
      Console.WriteLine("Hello world");
    }
    static void PrintMessage(string message)
    {
      Console.WriteLine("Hello " + message);
    }
    ....
    Action hello = new Action(PrintHello);
    Action<string> message = new Action<string>(PrintMessage);
    hello();
    message("my world");
