    public void DemoEvent(string val)
    {
        // Copy to a temporary variable to be thread-safe.
        EventHandler<btnEventArgs> temp = SampleEvent;
        if (temp != null)
            temp(this, new btnEventArgs { btnNumber = 2 });
    }
