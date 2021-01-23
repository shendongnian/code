    public ContactsDetailsControl(ProActive.Contact contact)
    {
       InitializeComponent();
       ItemsListBox.ItemsSource = MakeMeEnumerable<Contact>(contact);
    }
    
    private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
    {
        yield return Entity;
    }
