    private DateTime _lastEvent = DateTime.Now;
    public void Event()
    {
        if (_lastEvent + new TimeSpan(0, 0, 1) > DateTime.Now)
            return;
        _lastEvent = DateTime.Now;
        // Now do your event
        Console.WriteLine("Tick! " + _lastEvent);
    }
