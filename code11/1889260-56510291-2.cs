    private Contact _newContact;
    public Contact NewContact
    {
        get { return _newContact; }
        set { OnPropertyChanged(ref _newContact, value); }
    }
