    //Timer init.
     var _timer = new System.Timers.Timer
    {
        AutoReset = true, 
        Enabled = true,
        Interval = TimeSpan.FromSeconds(15).TotalMilliseconds //15 seconds interval
    };
     _timer.Elapsed += DoSomethingOnTimerElapsed;
    
    
    //To be called on timer elapsed.
    private void DoSomethingOnTimerElapsed(object source, ElapsedEventArgs e)
    {
        //Disable timer.
        _timer.Enabled = false; //or _timer.Stop()
        var markers = new Dictionary<string, ConversationItem>();
        try
        {
            //does long running process
        }
        catch (Exception ex)
        {
    
        }
        finally
        {
            if (_shouldEnableTimer) //set its default value to true.
                _timer.Enabled = true; //or _timer.Start()
        }
    }
    
    
    //somewhere in the code if you want to stop timer:
    _timer.Enabled = _shouldEnableTimer = false;
    
    //At any point, if you want to resume timer add this:
    _timer.Enabled = _shouldEnableTimer = true;
