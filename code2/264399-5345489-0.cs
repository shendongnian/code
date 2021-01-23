    // implement IEnumerable<T>
    public class GenericList<T> : IEnumerable<T>
    {
        #region Constructors
    
        public GenericList()
        {
        }
    
        public GenericList(IEnumerable<T> values)
            : this()
        {
            foreach (var val in values)
                this.AddNode(val);
        }
    
        #endregion
    
        #region IEnumerable Implementations
    
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }
    
        #endregion
    
        #region Nested Enumerator
    
        class Enumerator : IEnumerator<T>
        {
            private GenericList<T> innerList;
            private Node current;
            private bool started;
    
            public Enumerator(GenericList<T> list)
            {
                this.innerList = list;
                this.current = null;
                started = false;
            }
    
            public T Current
            {
                get
                {
                    if (!started)
                        throw new InvalidOperationException("You can't ask Current before calling MoveNext()");
                    return current.Data;
                }
            }
    
            object System.Collections.IEnumerator.Current
            {
                get { return this.Current; }
            }
    
            public bool MoveNext()
            {
                if (!started)
                {
                    current = innerList.head;
                    started = true;
                }
                else
                {
                    current = current.Next;
                }
                if (current != null)
                    return true;
                return false;
            }
    
            public void Reset()
            {
                started = false;
                current = null;
            }
    
            public void Dispose()
            {
            }
        }
    
        #endregion
    
        #region Your methods i.e. AddNode() etc.
        
        //...
        #endregion
    
    }
