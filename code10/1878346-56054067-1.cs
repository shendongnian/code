    private ObservableCollection<ObservableCollection<string>> _myCollection;
    public ObservableCollection<ObservableCollection<string>> MyCollection
    {
        get { return _myCollection; }
        set { _myCollection = value; NotifyPropertyChanged }
    }
