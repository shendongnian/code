    public MainPage()
    {
    InitializeComponent();
    Contacts objContacts = new Contacts();
    objContacts.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(objContacts_SearchCompleted);
    objContacts.SearchAsync(string.Empty, FilterKind.None, null);
    }
    void objContacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
    foreach (var result in e.Results)
    {
    lst.Add("Name : " + result.DisplayName + " ; Phone Number : " + result.PhoneNumbers.FirstOrDefault());
    }
    }
