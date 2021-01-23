    class MyClass : IList<T>, IList
    {
      ...
            object IList.this[int index]
            {
                get { return this[index]; }
                set { throw new NotSupportedException(); }
            }
    
            public int this[int index]
            {
                get { return items[i]; }
                set { throw new NotSupportedException(); }
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                for (int i = 0; i < count; i++)
                {
                    yield return items[i];
                }
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
      ...
    }
