    public struct WrappedEnumerable<T> : IEnumerable<T>
    {
        IEnumerable<T> _dataSource;
        public WrappedEnumerable(IEnumerable<T> dataSource)
        {
            _dataSource = dataSource;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _dataSource.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)_dataSource).GetEnumerator();
        }
    }
