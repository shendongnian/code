     private void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
          contacts = e.Results.ToArray();
          int n = 1;
          foreach (Contact contact in contacts)
          {
            contactList.Add(n, contact.DisplayName);
          }
        }
