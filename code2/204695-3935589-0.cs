    static void Main(string[] args)
    {
        System.Timers.Timer myTimer = new System.Timers.Timer(100);
        myTimer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
        myTimer.Start();
        Console.ReadLine();
    }
    static void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        ((System.Timers.Timer)sender).Stop();
        Console.WriteLine(DateTime.Now.ToString("HH.mm.ss"));
        System.Threading.Thread.Sleep(2000);
        ((System.Timers.Timer)sender).Start();
    }
