    static void Invoke(TimeSpan dueTime, Action action)
    {
        Timer timer = null;
        timer = new Timer(_ => { timer.Dispose(); action(); });
        timer.Change(dueTime, TimeSpan.FromMilliseconds(-1));
    }
