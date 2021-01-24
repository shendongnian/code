    private ObservableCollection<string> arr = new ObservableCollection<string>();
    public ObservableCollection<string> Arr
    {
        get => arr;
        set
        {
            if (arr != null) arr.CollectionChanged -= ArrCollectionChanged;
            arr = value;
            if (arr != null) arr.CollectionChanged += ArrCollectionChanged;
        }
    }
    private void ArrCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        AddCount();
    }
