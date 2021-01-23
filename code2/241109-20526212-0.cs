    private static void Main(string[] args)
    {
        ConsoleEventHooker.Closed += ConsoleEventHooker_Closed;
    }
    
    static void ConsoleHooker_Closed(object sender, EventArgs e)
    {
    }
