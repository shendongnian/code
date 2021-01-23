    class FancyCollectionAndPropertyChangedBase : INotifyPropertyChanged
    {
        private Dictionary<ICollectionChanged, String> collectionNameLookup = new Dictionary<ICollectionChanged, String>();
        protected FancyCollectionAndPropertyChangedBase()
        {
            this.PropertyChanged += MyPropertyChanged;
        }
        private void MyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(this.collectionNameLookup.ContainsValue(e.PropertyName)
            {
                KeyValuePair<INotifyCollectionChanged, String> oldValue = this.collectionNameLookup.First(kvp => kvp.Value == e.Name);
                oldValue.Key -= MyCollectionChanged;
                this.collecitonNameLookup.Remove(oldValue.Key);
                INotifyCollectionChanged collection = this.GetType().GetProperty(e.PropertyName, BindingFlags.FlattenHierarchy).GetValue(this, null);
                collection.CollectionChanged += MyCollectionChanged;
                this.collectionNameLookup.Add(collection, e.Name);
            }
            else if(typeof(INotifyCollectionChanged).IsAssignableFrom(this.GetType().GetProperty("",  BindingFlags.FlattenHierarchy).PropertyType))
            {
                // Note: I may have gotten the IsAssignableFrom statement, above, backwards. 
                INotifyCollectionChanged collection = this.GetType().GetProperty(e.PropertyName, BindingFlags.FlattenHierarchy).GetValue(this, null);
                collection.CollectionChanged += MyCollectionChanged;
                this.collectionNameLookup.Add(collection, e.Name);
            }
        }
        private void MyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.NotifyPropertyChanged(this.collectionNameLookup[sender];
        }
    }
