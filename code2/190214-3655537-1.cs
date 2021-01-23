        ObservableCollection<object> _yourCollection;
        public IEnumerable<IndexedObject> IndexedObjects
        {
            get
            {
                for (int i = 0; i < _yourCollection.Count; i++)
                {
                    yield return new IndexedObject(_yourCollection[i], i);
                }
            }
        }
