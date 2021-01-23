    public class OneShotEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _source;
        private bool _shouldThrow = false;
        public OneShotEnumerable(IEnumerable<T> source)
        {
            this._source = source;
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (_shouldThrow) throw new InvalidOperationException();
            _shouldThrow = true;
            return _source.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
