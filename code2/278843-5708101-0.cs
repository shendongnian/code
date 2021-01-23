    class DisposableWrapper<T> : where T : IDisposable {
        T _wrapped;
        public DisposableWrapper(T wrapped) {
            _wrapped = wrapped;
        }
        public T Item {
            get { return _wrapped; }
        }
        public void Dispose() {
            ((IDisposable)_wrapped).Dispose();
            // do extra stuff
        }
    }
