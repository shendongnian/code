    public class DisposableWrapper<T> : IDisposable
    {
        private readonly T _instance;
        private readonly IDisposable _disposable;
        public DisposableWrapper(T instance)
        {
            _instance = instance;
            _disposable = instance as IDisposable;
        }
        public void Dispose()
        {
            if (_disposable != null)
                _disposable.Dispose();
        }
        public static implicit operator T(DisposableWrapper<T> disposableWrapper)
        {
            return disposableWrapper._instance;
        }
    }
