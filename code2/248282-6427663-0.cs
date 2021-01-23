    class ActiveObject : IDisposable
    {
        private Task _lastTask = Task.Factory.StartNew(() => { });
    
        public void Dispose()
        {
            if (_lastTask == null)
                return;
    
            _lastTask.Wait();
            _lastTask = null;
        }
    
        public void InvokeAsync(Action action)
        {
            if (_lastTask == null)
                throw new ObjectDisposedException(GetType().FullName);
    
            _lastTask = _lastTask.ContinueWith(t => action());
        }
    }
