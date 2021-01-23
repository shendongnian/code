    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             int contactId;
             if (int.TryParse(Request.QueryString["contactid"], out contactId))
                 contact = Contact.Load(contactId);
             else
                 contact = new ContactId();
             DisplayContact(contact);  // Only one method to display new or existing record.
        }
    }
    protected void saveButton_Click(object sender, EventArgs args)
    {
        ReadContactFromPage(contact); // Only one method to read the screen.
        contact.Save();
    }
