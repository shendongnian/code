    XElement xmlDoc = XElement.Load(@"..\Users.xml");
    var users = from x in xmlDoc.Elements()
                select new User
                {                
                   Email = (string) x.Attribute("Email"),
                   Contacts = new List<Contact>(
                              from c in x.Elements()
                              select new Contact
                              {
                                  Name = (string) c.Attribute("Name"),
                                  Email = (string) c.Attribute("Email")
                              }
                   )
                };
