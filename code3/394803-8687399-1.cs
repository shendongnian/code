    private ObservableCollection<Person> _Person ;
    public ObservableCollection<Person> Person
    {
        get
        {  
            return _Person;
        }
        set
        {
            _Person = value;
            OnPrpertyChanged("Person");
        }
    }
