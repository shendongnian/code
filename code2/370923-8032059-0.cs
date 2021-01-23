    class Foo<TList, TItem> where TList : IList<TItem>, new()
    {
        private IList<TItem> _list = new TList();
        public Foo()
        {
        }
        public void Add(TItem item)
        {
            _list.Add(item);
        }
    }
