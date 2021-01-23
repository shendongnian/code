    private System.Timers.Timer _chatTimer = new System.Timers.Timer();
    
    public Form1()
    {
        InitializeComponents();
        
        _chatTimer.Interval = 1000;//1 seconds
        _chatTimer.Elapsed += OnChatTimerElapsed;
        _chatTimer.AutoReset = true;
    }
    
    private void OnChatTimerElapsed(object sender, System.Timer.ElapsedEventArts e)
    {
        //code to perform when timer elapsed.
    }
