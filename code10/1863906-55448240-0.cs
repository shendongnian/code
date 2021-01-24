    public class TupleList<T1, T2, T3> : IEnumerable<Tuple<T1, T2, T3>>
    {
        private List<Tuple<T1, T2, T3>> _list = new List<Tuple<T1, T2, T3>>();
        public void Populate(T1 item1, T2 item2, T3 item3)
        {
            _list.Add(Tuple.Create(item1, item2, item3));
        }
        public Tuple<T1, T2, T3> this[int index] { get => _list[index]; }
        public IEnumerator<Tuple<T1, T2, T3>> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
