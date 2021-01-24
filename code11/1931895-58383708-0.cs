    public CompletionListBehavior()
    {
        SetValue(ItemsProperty, new ObservableCollection<TextStyle>());
        Items.CollectionChanged += OnCollectionChanged;
    }
    
    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // The code when the collection is changed.
    }
