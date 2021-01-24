    private static void Main()
    {
        Console.WriteLine("Hello! The text below will flash red " + 
            "and green once per second until you press [Enter]");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.BackgroundColor = ConsoleColor.Green;
        while (FlashPrompt("Press escape to continue...", 
            TimeSpan.FromSeconds(1)) != ConsoleKey.Escape) ;
        Console.ResetColor();
        // Code will now continue in the original colors
    }
