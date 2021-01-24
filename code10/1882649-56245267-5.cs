    public ObservableCollection<Person> Persons { get; set; }
    private string _editName = null;
    public string EditName
    {
        get { return _editName; }
        set
        {
            _editName = value;
            OnPropertyChanged("EditName");
        }
    }
    private string _editCity = null;
    public string EditCity
    {
        get { return _editCity; }
        set
        {
            _editCity = value;
            OnPropertyChanged("EditCity");
        }
    }
