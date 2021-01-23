    public MainViewModel()
    {
        _dateTimer = new Timer(_dateTimer_Tick, Dispatcher, 0, 60000);
    }
    void _dateTimer_Tick(object state)
    {
        ((Dispatcher)state).Invoke(UpdateUI);
    }
    void UpdateUI()
    {
        Time = DateTime.Now.ToString("HH:mm");
        Date = DateTime.Now.ToString("D");
    }
