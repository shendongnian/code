    public static void Main()
    {
        // use own created context
        MainApplicationContext context = new MainApplicationContext();
        Application.Run(context);
    }
    
    // just quick way to demonstrate how we collect time changes
    public static BindingList<string> Logs { get; private set; }
    
    private class MainApplicationContext : ApplicationContext
    {
        private int _formCount;
        
        public MainApplicationContext()
        {
            Logs = new BindingList<string>();
    
            _formCount = 0;
            // splash screen
            var splash = new FormSplash();
            splash.Closed += OnFormClosed;
            splash.Load += OnFormOpening;
            splash.Closing += OnFormClosing;
            _formCount++;
            splash.Show();
            // For demo, make some logic that close splash when program loaded.
            Thread.Sleep(2000);
    
            var main = new FormMain();
            main.Closed += OnFormClosed;
            main.Load += OnFormOpening;
            main.Closing += OnFormClosing;
            _formCount++;
    
            splash.Close();
            main.Show();
        }
    
        private void OnFormOpening(object sender, EventArgs e)
        {
            SystemEvents.TimeChanged += SystemEvents_TimeChanged;
        }
    
        private void OnFormClosing(object sender, CancelEventArgs e)
        {
            SystemEvents.TimeChanged -= SystemEvents_TimeChanged;
        }
    
        private void OnFormClosed(object sender, EventArgs e)
        {
            _formCount--;
            if (_formCount == 0)
            {
                ExitThread();
            }
        }
        
        private void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            var text = $"TimeChanged, Time changed; it is now {DateTime.Now.ToLongTimeString()}";
            Logs.Add(text);
        }
    }
