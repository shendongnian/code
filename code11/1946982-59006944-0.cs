    public sealed class Foo: IEnumerable<int>
    {
        public void Add(int item)
        {
            _items.Add(item);
        }
        public IEnumerator<int> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        readonly List<int> _items = new List<int>();
    }
