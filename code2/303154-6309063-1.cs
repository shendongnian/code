    using System.DirectoryServices;
    ...
    
    
        DirectoryEntry entry = new DirectoryEntry("LDAP://<your_dn_here>");
        object[] entries = addressBookValues.Split(',');
        entry.Properties["ShowInAddressBook"].AddRange(entries);
        
        try 
        { 
        entry.CommitChanges(); 
        Console.WriteLine("Success!!");
         }
         catch(Exception e) 
        {
         Console.WriteLine(e);
         } 
