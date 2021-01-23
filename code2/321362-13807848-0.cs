    public class SplitFirstEnumerable<T>
    {
        private readonly IEnumerator<T> _enumerator;
        public SplitFirstEnumerable(IEnumerable<T> enumerable)
        {
            _enumerator = enumerable.GetEnumerator();
            First = _enumerator.Current;
        }
        public IEnumerable<T> Remaining
        {
            get
            {
                while (_enumerator.MoveNext())
                {
                    yield return _enumerator.Current;
                }
            }
        }
        public T First { get; private set; }
    }
