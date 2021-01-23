    public struct WebBrowserAwaiter<T>
    {
        public bool IsCompleted { get { ... } }
        public void OnCompleted(Action continuation) { ... }
        public T GetResult() { ... }
    }
