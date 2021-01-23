    public Account GetAccount(string email)
    {
        var context = new ServiceContext(_service);
        var domain = email.Substring(email.IndexOf('@'));
        var contacts = from c in context.ContactSet
                       where c.EMailAddress1.Contains(domain)
                       where c.StateCode == ContactState.Active
                       where c.ParentCustomerId != null
                       select c;
        
        return RetrieveEntity(Account.EntityLogicalName, contacts.First<Contact>().ParentCustomerId.Id, new ColumnSet(true)).ToEntity<Account>();
    }
