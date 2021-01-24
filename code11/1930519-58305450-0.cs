    public Person NewPerson
    {
        get
        {
            return _newPerson;
        }
        set
        {
            _newPerson = value;
            OnPropertyChanged(nameof(AddPersonCanExecute));
            OnPropertyChanged(nameof(NewPerson));
        }
    }
