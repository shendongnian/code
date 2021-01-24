    static void Main(string[] args)
    {
        Timer timer1 = new Timer(1000)
        {
            Enabled = true,
            AutoReset = true
        };
        Timer timer2 = new Timer(2000)
        {
            Enabled = true,
            AutoReset = true
        };
        Timer timer3 = new Timer(3000)
        {
            Enabled = true,
            AutoReset = true
        };
        timer1.Elapsed += async (sender, e) => await HandleTimer("Timer1");
        timer2.Elapsed += async (sender, e) => await HandleTimer("Timer2");
        timer3.Elapsed += async (sender, e) => await HandleTimer("Timer3");
        Console.ReadLine();
    }
    private static async Task HandleTimer(string message)
    {
        Console.WriteLine(message);
    }
