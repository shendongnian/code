    public List(IEnumerable<T> collection)
    {
            ...
            ICollection<T> c = collection as ICollection<T>;
            if( c != null) {
                int count = c.Count;
                if (count == 0)
                {
                    _items = _emptyArray;
                }
                else {
                    _items = new T[count];
                    c.CopyTo(_items, 0);
                    _size = count;
                }
            }   
            ...
    } 
