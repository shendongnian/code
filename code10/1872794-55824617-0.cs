    public List(IEnumerable<T> collection) {
    	ICollection<T> c = collection as ICollection<T>;
        // (1) count is now current Count of collection
  		int count = c.Count;
        // other threads can modify collection meanwhile
   		if (count == 0)
   		{
   			_items = _emptyArray;
   		}
   		else {
   			_items = new T[count];
            // (2) SynchronizedCollection.CopyTo is called (which itself is thread-safe)
            // Collection can still be modified between (1) and (2) 
            // No when _items.Count != c.Count -> Exception is raised.
   			c.CopyTo(_items, 0);
   			_size = count;
   		}
    }
