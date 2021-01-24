    public class TrackingDisposer : IDisposable
    {
        private readonly LinkedList<Task> _tasks = new LinkedList<Task>();
        private readonly ITrackingDisposable _target;
        public bool IsDisposed { get; private set; } = false;
        //The supported class must implement ITrackingDisposable
        public TrackingDisposer(ITrackingDisposable target)
        => _target = target ?? throw new ArgumentNullException();
        //Add a task to the tracking list, returns false if disposed
        //Without return value
        public bool Track(Func<Task> func, out Task result)
        {
            lock (_tasks)
            {
                if (IsDisposed)
                {
                    result = null;
                    return false;
                }
                var task = func();
                var node = _tasks.AddFirst(task);
                async Task ending()
                {
                    await task;
                    var dispose = false;
                    lock (_tasks)
                    {
                        _tasks.Remove(node);
                        dispose = IsDisposed && _tasks.Count == 0;
                    }
                    if (dispose)
                    {
                        await _target.FinishDisposeAsync();
                    }
                }
                result = ending();
            }
            return true;
        }
        //With return value
        public bool Track<TResult>(Func<Task<TResult>> func, out Task<TResult> result)
        {
            lock (_tasks)
            {
                if (IsDisposed)
                {
                    result = null;
                    return false;
                }
                var task = func();
                var node = _tasks.AddFirst(task);
                async Task<TResult> ending()
                {
                    var result = await task;
                    var dispose = false;
                    lock (_tasks)
                    {
                        _tasks.Remove(node);
                        dispose = IsDisposed && _tasks.Count == 0;
                    }
                    if (dispose)
                    {
                        await _target.FinishDisposeAsync();
                    }
                    return result;
                }
                result = ending();
            }
            return true;
        }
        //The entry of applying for dispose
        public void Dispose()
        {
            var dispose = false;
            lock (_tasks)
            {
                IsDisposed = true;
                dispose = _tasks.Count == 0;
            }
            if (dispose)
            {
                _target.FinishDisposeAsync();
            }
        }
    }
