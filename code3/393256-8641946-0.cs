    private var _Callbacks = new List<PropertyChangedEventHandler>();
    public event PropertyChangedEventHandler PropertyChanged
    {
        add
        {
            lock(_Callbacks)
                _Callbacks.Add(value);
            Thread Worker = new Thread(PollTime);
            Worker.Background = true;
            Worker.Start(value);
        }
        remove
        {
            lock(_Callbacks)
                _Callbacks.Remove(value);
        }
    }
    private void PollTime(object callback)
    {
        PropertyChangedEventHandler c = (PropertyChangedEventHandler)callback;
        string LastReported = null;
        while(true)
        {
            lock(_Callbacks)
                if (!_Callbacks.Contains(c))
                    return;
            if (LastReported != _currentTime)
            {
                LastReported = _currentTime;
                c(this, new PropertyChangedEventArgs(name));
            }
            else
                Thread.Sleep(10);
        }
    }
    public string currentTime
    {
        get { return _currentTime; }
        set { _currentTime= value; } 
    }
