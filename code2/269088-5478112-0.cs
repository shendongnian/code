    private static char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    ...
    
    public void GetAllContacts()
    {
       int initialLetterIndex = 0;
      _lyncClient.ContactManager.BeginSearch(
        Alphabet[initialLetterIndex].ToString();
        SearchProviders.GlobalAddressList,
        SearchFields.FirstName,
        SearchOptions.ContactsOnly,
        300,
        SearchAllCallback
        new object[] { initialLetterIndex, new List<Contact>() }
      );
    }
    private void SearchAllCallback(IAsyncResult result)
    {
      object[] parameters = (object[])result.AsyncState;
      int letterIndex = (int)parameters[0] + 1;
      List<Contact> contacts = (List<Contact>)parameters[1];
      SearchResults results = _lyncClient.ContactManager.EndSearch(result);
      contacts.AddRange(results.Contacts);
      if (letterIndex < Alphabet.Length)
      {
        _lyncClient.ContactManager.BeginSearch(
          Alphabet[letterIndex].ToString(), 
          SearchAllCallback, 
          new object[] { letterIndex, contacts }
        );
      }
      else
      {
        //Now that we have all the contacts 
        //trigger an event with 'contacts' as the event arguments.
      }
    }
