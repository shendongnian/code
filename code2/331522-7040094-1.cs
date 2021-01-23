    public class DisposableEvenlope<T> : IEnumerator<T>
    {
        private IEnumerator<T> _privateEnum;
        public event System.EventHandler Disposed;
        public DisposableEvenlope(IEnumerator<T> privateEnum)
        {
            _privateEnum = privateEnum;
        }
        public T Current
        {
            get { return _privateEnum.Current; }
        }
        public void Dispose()
        {
            Disposed(this, new System.EventArgs());
        }
        object IEnumerator.Current
        {
            get { return _privateEnum.Current; }
        }
        public bool MoveNext()
        {
            return _privateEnum.MoveNext();
        }
        public void Reset()
        {
            _privateEnum.Reset();
        }
    }
