        public class GoogleContactsProvider : IContactProvider
    {
        #region IContactProvider Members
        /// <summary>
        /// Gets the contacts list form the contact provider.
        /// </summary>
        /// <returns></returns>
        public EntityCollection<IContactItem> GetContactsList()
        {
            EntityCollection<IContactItem> collection = new EntityCollection<IContactItem>();
            // Setup the contacts request (autopage true returns all contacts)
            RequestSettings requestSettings = new RequestSettings("AgileMe", UserName, Password);
            requestSettings.AutoPaging = true;
            ContactsRequest contactsRequest = new ContactsRequest(requestSettings);
            // Get the feed
            Feed<Contact> feed = contactsRequest.GetContacts();
            // create our collection by looping through the feed
            foreach (Contact contact in feed.Entries)
            {
                GoogleContactItem newContact = new GoogleContactItem();
                newContact.Name = contact.PrimaryEmail.Address;
                newContact.Summary = contact.Summary;
                collection.Add(newContact);
            }
            return collection;
        }
        /// <summary>
        /// Gets or sets the name of the user for the contact provider.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password for the contact provider.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        #endregion
    }
