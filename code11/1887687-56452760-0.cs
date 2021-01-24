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
    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        //make the Discord.Net api call to update status here instead of this console.writeline
        Console.WriteLine($"{ status.ElementAt(currentStatus)}",
                              e.SignalTime);
        currentStatus = currentStatus < status.Count - 1 ? currentStatus +=1 : currentStatus = 0;
    }
