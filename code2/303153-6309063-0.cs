    using System.DirectoryServices;
    ...
    
    
        DirectoryEntry entry = new DirectoryEntry("LDAP://<your_dn_here>");
        
        entry.Properties["ShowInAddressBook"] = new object[]{"ShowInAddressBook", addressBookValues.Split(',');
        
        try 
        { 
        entry.CommitChanges(); 
        Console.WriteLine("Success!!");
         }
         catch(Exception e) 
        {
         Console.WriteLine(e);
         } 
