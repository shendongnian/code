    public MailingAddress {
       get {
          return Addresses.Where(a => a.IsPrimaryMailing).FirstOrDefault();
       }
    }
