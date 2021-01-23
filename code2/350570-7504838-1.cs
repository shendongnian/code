    static System.Threading.Timer processTimer;
    
    static void Main(string[] args)
    {
        processTimer = new System.Threading.Timer(new   TimerCallback(processTimerCallback), null, 2000, 2000);
        Application.Run(form = new MainForm());
    }
