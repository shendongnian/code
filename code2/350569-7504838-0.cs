    static void Main(string[] args)
    {
        System.Threading.Timer processTimer = new System.Threading.Timer(new   TimerCallback(processTimerCallback), null, 2000, 2000);
        Application.Run(form = new MainForm());
        GC.KeepAlive(processTimer);
    }
