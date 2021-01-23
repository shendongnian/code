    string manager = directoryEntry.Properties["manager"].Value;
    // check what is stored in "manager" ! It needs to be a **full** LDAP path
    // something like `LDAP://..........`
    using (DirectoryEntry manager = new DirectoryEntry(manager))
    {
       try
       {
          contact.ManagersGuid = manager.NativeGuid;
       }
       catch(Exception ex)
       {
           // log and handle the exception, if something goes wrong....
       }
    }
