    void Page_Load()
    {
        if (!IsPostBack)
        {
             int contactId = // get the contact ID from the query string.
             if (contactId == 0)
                 contact = new ContactId();
             else
                 contact = Contact.Load(contactId);
             DisplayContact(contact);  // Only one method to display new or existing record.
        }
    }
    protected void saveButton_Click(object sender, EventArgs args)
    {
        ReadContactFromPage(contact); // Only one method to read the screen.
        contact.Save();
    }
