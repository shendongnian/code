    static void Main(string[] args)
    {
        var container = Container.For<ConsoleRegistry>();
 
        var app = container.GetInstance<Application>();
        app.Run();
        Console.ReadLine();
    }
