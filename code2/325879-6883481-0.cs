    public sealed class ListReference<T>
    {
        private readonly IList<T> _list;
        private readonly int _index;
        public ListReference(IList<T> list, int index)
        {
            _list = list;
            _index = index;
        }
        public T Value
        {
            get { return _list[_index]; }
            set { _list[_index] = value; }
        }
    }
