    private DateTime startTime;
    public void startTimer() {
        startTime = DateTime.Now;
    }
    public void refreshTimeBox(object param)
    {
        Dispatcher.BeginInvoke(WriteTimeBox);
    }
    public void WriteTimeBox()
    {
        TimeSpan ts = DateTime.Now - startTime;
        // See http://msdn.microsoft.com/en-us/library/1ecy8h51.aspx for TimeSpan formatting.
        TimeBar.Text = ts.time.ToString("s.ff");
    }
