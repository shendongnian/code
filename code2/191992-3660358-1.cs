    public class ConvertingList<TSrc, TDest> : IList<TDest>
    {
      private readonly IList<TSrc> _inner;
      private readonly Func<TSrc, TDest> _conv;
      public ConvertingList(IList<TSrc> inner, Func<TSrc, TDest> conv)
      {
          _inner = inner;
          _conv = conv;
      }
      public TDest this[int index]
      {
          get
          {
              return ReferenceEquals(null, _inner[index]) ? default(TDest) : _conv(_inner[index]);
          }
          set
          {
            throw new NotSupportedException("Readonly collection");
          }
      }
      public int Count
      {
          get
          {
            return _inner.Count;
          }
      }
      public bool IsReadOnly
      {
          get
          {
            return true;
          }
      }
      public int IndexOf(TDest item)
      {
          if(ReferenceEquals(item, null))
          {
            for(int i = 0; i != Count; ++i)
              if(ReferenceEquals(this[i], null))
                return i;
          }
          else
          {
            for(int i = 0; i != Count; ++i)
              if(item.Equals(this[i]))
                return i;
          }
          return -1;
      }
      public void Insert(int index, TDest item)
      {
          throw new NotSupportedException("Readonly collection");
      }
      public void RemoveAt(int index)
      {
          throw new NotSupportedException("Readonly collection");
      }
      public void Add(TDest item)
      {
          throw new NotSupportedException("Readonly collection");
      }
      public void Clear()
      {
          throw new NotSupportedException("Readonly collection");
      }
      public bool Contains(TDest item)
      {
          return IndexOf(item) != -1;
      }
      public void CopyTo(TDest[] array, int arrayIndex)
      {
          if(array == null)
            throw new ArgumentNullException();
    		if(arrayIndex < 0)
    			throw new ArgumentOutOfRangeException();
    		if(array.Rank != 1 || array.Length < arrayIndex + Count)
    			throw new ArgumentException();
    		foreach(TDest item in this)
    		  array[arrayIndex++] = item;
      }
      public bool Remove(TDest item)
      {
          throw new NotSupportedException("Readonly collection");
      }
      public IEnumerator<TDest> GetEnumerator()
      {
          foreach(TSrc srcItem in _inner)
            yield return ReferenceEquals(null,srcItem) ? default(TDest) : _conv(srcItem)
      }
      IEnumerator IEnumerable.GetEnumerator()
      {
          return GetEnumerator();
      }
    }
