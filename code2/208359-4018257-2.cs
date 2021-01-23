    public class Client
    {
    
      private readonly ISet<Contact> contacts;
    
      public Client()
      {
        contacts = new HashedSet<Contact>();
      }
    
      public IEnumerable<Contact> Contacts
      {
        get { return contacts; }
      }
    
      public void LogCall(string description)
      {
         var contact = new Contact(description, this);
         AddContact(contact);
      }
    
      internal void AddContact(Contact contact) 
      { 
        contacts.Add(contact);
      }
    
      internal void RemoveContact(Contact contact)
      {
        contacts.Remove(contact);
      }
    }
    
    public class Contact
    {
      protected Contact { }
    
      public Contact(string description, Client client)
      {
        if (description == null) throw new ArgumentNullException("description");
        if (client == null) throw new ArgumentNullException("client");
    
        Client = client;
        Description = description;
      }
    
      public Client Client { get; private set; }
    
      public string Description { get;private set; }
    
      // I assumed that moving a contact to another client would only be done by the user to correct mistakes?
      // Isn't it an UI problem when the user frequently makes this mistake?
      public void CorrectMistake(Client client)
      {
        Client.RemoveContact(this);
        Client = client;
        client.AddContact(this);
      }
    }
