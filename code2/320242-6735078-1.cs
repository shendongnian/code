    private string _title;
    public string Title {
        get {return _title;}
        set {_title = value; RaisePropertyChanged("Title");}
    }
    private string _description;
    public string Description {
        get {return _description;}
        set {_description= value; RaisePropertyChanged("Description");}
    }
    public ObservableCollection Workers {get; private set;}
    public Constructor()
    {
        Workers = new ObservableCollection();
    }
