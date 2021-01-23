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
    //This method is called by the model once it has fetched data.
    //This can be done as a callback or in an event handler
    public CalledByTheModelAfterLoadingData(Department department)
    {
        Title = department.Title;
        Description = department.Description;
        foreach (var worker in department.Workers)
        {
            Workers.Add(worker);
        }
    }
