    public class FileAccessWatcher
    {
    public Dictionary<string, DateTime> _trackedFiles = new Dictionary<string, DateTime>();
    private Timer _timer;
    public event EventHandler<EventArgs<string>> FileAccessed = delegate { };
    public FileAccessWatcher()
    {
        _timer = new Timer(OnTimerTick, null, 500, Timeout.Infinite);
    }
    public void Watch(string path)
    {
        _trackedFiles[path] = File.GetLastAccessTime(path);
    }
    public void OnTimerTick(object state)
    {
        foreach (var pair in _trackedFiles.ToList())
        {
            var accessed = File.GetLastAccessTime(pair.Key);
            if (pair.Value != accessed)
            {
                _trackedFiles[pair.Key] = accessed;
                FileAccessed(this, new EventArgs<string>(pair.Key));
            }
        }
        _timer.Change(500, Timeout.Infinite);
    }
    }
