      [CollectionDataContract(Name = "Centres")]
      public class Centres : IList<Centre>
        {
            private IList<Centre> _inner;
            private IList<Centre> Inner
            {
                get
                {
                    if (_inner == null)
                        _inner = new List<Centre>();
                    return _inner;
                }
            }
            public Centres(List<Centre> items)
            {
                _inner = items;
            }
    
            #region IList<Centre> Members
    
            public int IndexOf(Centre item)
            {
                return Inner.IndexOf(item);
            }
    
            public void Insert(int index, Centre item)
            {
                Inner.Insert(index, item);
            }
    
            public void RemoveAt(int index)
            {
                Inner.RemoveAt(index);
            }
    
            public Centre this[int index]
            {
                get
                {
                    return Inner[index];
                }
                set
                {
                    Inner[index] = value;
                }
            }
    
            #endregion
    
            #region ICollection<Centre> Members
    
            public void Add(Centre item)
            {
                Inner.Add(item);
            }
    
            public void Clear()
            {
                Inner.Clear();
            }
    
            public bool Contains(Centre item)
            {
                return Inner.Contains(item);
            }
    
            public void CopyTo(Centre[] array, int arrayIndex)
            {
                Inner.CopyTo(array, arrayIndex);
            }
    
            public int Count
            {
                get { return Inner.Count; }
            }
    
            public bool IsReadOnly
            {
                get { return Inner.IsReadOnly; }
            }
    
            public bool Remove(Centre item)
            {
                return Inner.Remove(item);
            }
    
            #endregion
    
            #region IEnumerable<Centre> Members
    
            public IEnumerator<Centre> GetEnumerator()
            {
                return Inner.GetEnumerator();
            }
    
            #endregion
    
            #region IEnumerable Members
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return Inner.GetEnumerator();
            }
    
            #endregion
        }
