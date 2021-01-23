    public void DemoEvent(string val)
    {
        // Copy to a temporary variable to be thread-safe.
        EventHandler<MyEventArgs> temp = SampleEvent;
        if (temp != null)
            temp(this, new MyEventArgs { btnNumber = 2 });
    }
