    public string FullName
    {
        get { return firstname + " " + lastname; }
    }
    public string LastName
    {
        get { return lastname; }
        set
        {
            lastname = value;
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(FullName));
        }
    }
    public string FirstName
    {
        get { return firstname; }
        set
        {
            firstname = value;
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(FullName));
        }
    }
