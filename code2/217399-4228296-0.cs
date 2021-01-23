    public Form1()
    {
        InitializeComponent();
        
        // You need to figure out how best to do this part.
        // Also, what to do if the main-app isn't already running.
        var mainAppProcess = Process.GetProcessesByName("MainApp").First();
        mainAppProcess.EnableRaisingEvents = true;
       
        // Close the form when the other process exits.
        mainAppProcess.Exited +=
            delegate { BeginInvoke(new Action(Close)); };
    }
