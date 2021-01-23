    // subscribe to CollectionChanged event of the ObservableCollection
    _recordingsHidden.CollectionChanged += RecordingsHiddenOnCollectionChanged;
    private void RecordingsHiddenOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
            var view = (CollectionView)CollectionViewSource.GetDefaultView(lvCallHistory.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("StartTime", ListSortDirection.Descending));
    }
