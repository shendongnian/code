    ObservableCollection<Phone> _contactPhones;
    [DataMember]
    public ObservableCollection<Phone> ContactPhones
    {
        get { return _contactPhones ?? (
            contactPhones = new ObservableCollection<Phone>());
    }
