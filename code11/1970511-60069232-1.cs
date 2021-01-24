    class ChangeToken : IChangeToken, IDisposable
    {
        private volatile bool _hasChanged;
        private readonly ConcurrentQueue<(Action<object>, object)>
            registeredCallbacks = new ConcurrentQueue<(Action<object>, object)>();
        public void SignalChanged()
        {
            _hasChanged = true;
            while (registeredCallbacks.TryDequeue(out var entry))
            {
                var (callback, state) = entry;
                callback?.Invoke(state);
            }
        }
        bool IChangeToken.HasChanged => _hasChanged;
        bool IChangeToken.ActiveChangeCallbacks => true;
        IDisposable IChangeToken.RegisterChangeCallback(Action<object> callback,
            object state)
        {
            registeredCallbacks.Enqueue((callback, state));
            return this; // return null doesn't work
        }
        void IDisposable.Dispose() { } // It is called by the framework after each callback
    }
