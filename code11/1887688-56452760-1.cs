    private static Timer timer;
    private static List<string> status => new List<string>() { "Status1", "Status2", "Status3", "Status4" };
    private static int currentStatus = 0;
    static void Main(string[] args)
    {
        CreateTimer();
        Console.ReadLine();
        timer.Stop();
        timer.Dispose();
    }
    private static void CreateTimer()
    {
        timer = new Timer(10000);
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;
    }
    private static async void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        DiscordSocketClient client = new DiscordSocketClient(new DiscordSocketConfig()
        {
             //Set config values, most likely API Key etc
        });
        await client.SetGameAsync("Game Name", status.ElementAtOrDefault(currentStatus), ActivityType.Playing);
        currentStatus = currentStatus < status.Count - 1 ? currentStatus +=1 : currentStatus = 0;
    }
