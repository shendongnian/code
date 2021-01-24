    private PersonViewModel _contactViewModel
    public PersonViewModel Contact
    {
        get { return _contactViewModel ?? (_contactViewModel = new PersonViewModel(_contact)); }
    }
