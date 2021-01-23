      List<object> GetContactInfo() {
        List<object> list = new List<object>();
        foreach ( Contact c in allContacts ) { 
            list.Add( new { 
                ContactID = c.ContactID, 
                FullName = c.FullName 
            }); 
        } 
        return list;
      }
