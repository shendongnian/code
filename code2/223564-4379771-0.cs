    private System.Threading.Timer myTimer;
    
    private void StartTimer()
    {
            myTimer = new System.Threading.Timer(TimerTick, null, 0, 5000);
    }
    
    private void TimerTick(object state)
    {
        Console.WriteLine("Tick");
    }
