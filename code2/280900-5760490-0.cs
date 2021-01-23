    static void Main(string[] args)
    {
        SetTimer();
        Console.ReadLine();
    }
    private static void SetTimer()
    {
        Timer expirationTimer = new Timer(1000);
        expirationTimer.Elapsed += (sender, e) => Notify(e);
        expirationTimer.Start();
    }
    private static void Notify(ElapsedEventArgs e)
    {
        Console.WriteLine(string.Format("Notified! {0}", e.SignalTime));   
    }
