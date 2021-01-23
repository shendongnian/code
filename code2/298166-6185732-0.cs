    [STAThread]
    Main(...)
    {
        var comObject = new YourComObject();
        comObject.Event += EventHandler;
        Console.WriteLine("Press enter to exit.");
        Console.ReadLine();
    }
    void EventHandler(...)
    {
        // Handle the event
    }
