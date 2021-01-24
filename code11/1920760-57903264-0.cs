    private ObservableCollection<T> yourList = new ObservableCollection<Hole>();
    public ObservableCollection<T> YourList
    {
        get { return yourList; }
        set
        {
            this.yourList = value;
            NotifyPropertyChanged("YourList");
        }
    }
