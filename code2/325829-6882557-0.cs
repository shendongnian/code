    OutlookSession session = new OutlookSession();
    ContactCollection contacts = session.Contacts.Items;
    foreach (Contact contact in contacts)
    { 
       // Supposing that lstContacts is a ListBox on a form
       lstContacts.Items.Add(contact.FirstName + contact.LastName);
    }
