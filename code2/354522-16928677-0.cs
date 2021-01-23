    static class Async
    {
        public static Task<IDisposable> Lock(object obj)
        {
            return TaskEx.Run(() =>
                {
                    var resetEvent = ResetEventFor(obj);
     
                    resetEvent.WaitOne();
                    resetEvent.Reset();
     
                    return new ExitDisposable(obj) as IDisposable;
                });
        }
     
        private static readonly IDictionary<object, WeakReference> ResetEventMap =
            new Dictionary<object, WeakReference>();
     
        private static ManualResetEvent ResetEventFor(object @lock)
        {
            if (!ResetEventMap.ContainsKey(@lock) ||
                !ResetEventMap[@lock].IsAlive)
            {
                ResetEventMap[@lock] =
                    new WeakReference(new ManualResetEvent(true));
            }
     
            return ResetEventMap[@lock].Target as ManualResetEvent;
        }
     
        private static void CleanUp()
        {
            ResetEventMap.Where(kv => !kv.Value.IsAlive)
                         .ToList()
                         .ForEach(kv => ResetEventMap.Remove(kv));
        }
     
        private class ExitDisposable : IDisposable
        {
            private readonly object _lock;
     
            public ExitDisposable(object @lock)
            {
                _lock = @lock;
            }
     
            public void Dispose()
            {
                ResetEventFor(_lock).Set();
            }
     
            ~ExitDisposable()
            {
                CleanUp();
            }
        }
    }
