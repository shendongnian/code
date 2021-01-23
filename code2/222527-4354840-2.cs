    class SortedListBase<T, TList> where TList : IList<T>, new()
    {
        protected TList _list = new TList();
    
        // Here's a method I can provide using any IList<T> implementation.
        public T this[int index]
        {
            get { return _list[index]; }
        }
    
        // Here's one way I can ensure the list is always sorted. Better ways
        // might be available for certain IList<T> implementations...
        public virtual void Add(T item)
        {
            IComparer<T> comparer = Comparer<T>.Default;
            for (int i = 0; i < _list.Count; ++i)
            {
                if (comparer.Compare(item, _list[i]) < 0)
                {
                    _list.Insert(i, item);
                    return;
                }
            }
    
            _list.Add(item);
        }
    }
    
    class SortedList<T> : SortedListBase<T, List<T>>
    {
        // Here is a smarter implementation, dependent on List<T>'s
        // BinarySearch method. Note that this implementation would not
        // be possible (or anyway, would be less direct) if SortedListBase's
        // _list member were simply defined as IList<T>.
        public override void Add(T item)
        {
            int insertionIndex = _list.BinarySearch(item);
    
            if (insertionIndex < 0)
            {
                insertionIndex = ~insertionIndex;
            }
    
            _list.Insert(insertionIndex, item);
        }
    }
