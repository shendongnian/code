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
        protected Task Track(Func<Task> func)
        => _disposer.Track(func, out var result)
            ? result
            : throw new ObjectDisposedException(nameof(TrackingDisposable));
        protected Task<TResult> Track<TResult>(Func<Task<TResult>> func)
        => _disposer.Track(func, out var result)
            ? result
            : throw new ObjectDisposedException(nameof(TrackingDisposable));
    }
