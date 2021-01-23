    void c_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (((ObservableCollection<string>)sender).Count == 0)
        {
            // Action here
        }
    }
