    Person myPerson = new Person(); //*****
    public Person GetRandomPerson(string s)
    {
        Person contacts = new Contacts();            
        contacts.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(contacts_SearchCompleted);
        contacts.SearchAsync(String.Empty, FilterKind.None, "All Contacts");            
        wait.WaitOne();      //*****
        return myPerson;    //I'm not sure how this will ever work...
    }
    ManualResetEvent wait = new ManualResetEvent(false); //*****
    void contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
        //Fill myPerson
        wait.Set(); //*****
    }
