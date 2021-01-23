    private void Restart()
    {
        Process.Start(Application.ExecutablePath);
    
        //some time to start the new instance.
        Thread.Sleep(2000);
    
        Environment.Exit(-1);//Force termination of the current process.
    }
    private static void Main()
    {
        //wait because we maybe here becuase of the system is restarted so give it some time to clear the old instance first
        Thread.Sleep(5000);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(...
    }
