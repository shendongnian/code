    public interface ITrackingDisposable : IDisposable, IAsyncDisposable
    {
        Task FinishDisposeAsync();
    }
    public class TrackingDisposer : IDisposable, IAsyncDisposable
    {
        private readonly LinkedList<Task> _tasks = new LinkedList<Task>();
        private readonly ITrackingDisposable _target;
        private readonly TaskCompletionSource<object> _disposing = new TaskCompletionSource<object>();
        public bool IsDisposed { get; private set; } = false;
        public TrackingDisposer(ITrackingDisposable target)
        => _target = target ?? throw new ArgumentNullException();
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
                        _disposing.SetResult(null);
                    }
                }
                result = ending();
            }
            return true;
        }
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
                        _disposing.SetResult(null);
                    }
                    return result;
                }
                result = ending();
            }
            return true;
        }
        public void Dispose()
        {
            var dispose = false;
            lock (_tasks)
            {
                if (IsDisposed)
                {
                    return;
                }
                IsDisposed = true;
                dispose = _tasks.Count == 0;
            }
            if (dispose)
            {
                _target.FinishDisposeAsync();
                _disposing.SetResult(null);
            }
        }
        public ValueTask DisposeAsync()
        {
            Dispose();
            return new ValueTask(_disposing.Task);
        }
    }
    public abstract class TrackingDisposable : ITrackingDisposable
    {
        private readonly TrackingDisposer _disposer;
        public TrackingDisposable()
        => _disposer = new TrackingDisposer(this);
        protected virtual void FinishDispose() { }
        protected virtual Task FinishDisposeAsync()
        => Task.CompletedTask;
        Task ITrackingDisposable.FinishDisposeAsync()
        {
            FinishDispose();
            return FinishDisposeAsync();
        }
        public void Dispose()
        => _disposer.Dispose();
        public ValueTask DisposeAsync() => _disposer.DisposeAsync();
        protected Task Track(Func<Task> func)
        => _disposer.Track(func, out var result)
            ? result
            : throw new ObjectDisposedException(nameof(TrackingDisposable));
        protected Task<TResult> Track<TResult>(Func<Task<TResult>> func)
        => _disposer.Track(func, out var result)
            ? result
            : throw new ObjectDisposedException(nameof(TrackingDisposable));
    }
