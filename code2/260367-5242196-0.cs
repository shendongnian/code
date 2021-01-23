    static void Main()
    {
        Microsoft.Win32.SystemEvents.SessionEnding += new Microsoft.Win32.SessionEndingEventHandler(SystemEvents_SessionEnding);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
    
    static void SystemEvents_SessionEnding(object sender, Microsoft.Win32.SessionEndingEventArgs e)
    {
        // Do something
    }
