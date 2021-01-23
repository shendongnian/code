    public void DemoEvent(int val)
    {
        // Copy to a temporary variable to be thread-safe.
        EventHandler<btnEventArgs> temp = listTopicPerPage_Click;
        if (temp != null)
            temp(this, new btnEventArgs { btnNumber = val });
    }
