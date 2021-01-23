        class MyCollection : INotifyEnumerableCollectionChanged<T>. 
                             IEnumerable<String>, INotifyCollectionChanged
        {
            IEnumerator<String> IEnumerable<String>.GetEnumerator()
            { throw new NotImplementedException(); }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            { throw new NotImplementedException(); }
            public event NotifyCollectionChangedEventHandler CollectionChanged;
        }
