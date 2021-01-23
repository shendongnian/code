    Session s = new Session(AuthParam.Login, AuthParam.Password);
    
    s.Connected += (sender, eventArgs) => 
      {
        _contactCollection = s.ContactList.Contacts.Select(x => new Contact(x.Nickname, x.Uin)).ToList();
      };
    
    s.ConnectionError += (sender, eventArgs) =>
      {
      };
         
    s.Connect();
               
