    public static void Main(string[] args)
    {
        check_news();
        Console.ReadKey();
    }
    private static void check_news()
    {
        Thread t = new Thread(() =>
            {
                // Check news here
                Thread.Sleep(1000); // Dummy
            });
        t.Priority = ThreadPriority.Lowest; // Priority of the thread
        t.IsBackground = true; // Set it as background (allows you to stop the application while news is fetching
        t.Name = "News checker"; // Make it recognizable
        t.Start(); // And start it
    }
