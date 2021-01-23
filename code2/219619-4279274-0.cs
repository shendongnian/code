    class Handler
    {
        private ObservableCollection<string> collection;
        public Handler()
        {
            collection = new ObservableCollection<string>();
            collection.CollectionChanged += HandleChange;
        }
        private void HandleChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (var x in e.NewItems)
            {
                // do something
            }
            foreach (var y in e.OldItems)
            {
                //do something
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {
                //do something
            }
        }
    }
