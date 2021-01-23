    static void Main(string[] args)
    {
      //Connection to Active Directory
      string sFromWhere = "LDAP://SRVENTR2:389/dc=societe,dc=fr";
      DirectoryEntry deBase = new DirectoryEntry(sFromWhere, "societe\\administrateur", "test.2011");
    
      // To find all the users member of groups "Grp1"  :
      // Set the base to the groups container DN; for example root DN (dc=societe,dc=fr) 
      // Set the scope to subtree
      // Use the following filter :
      // (member:1.2.840.113556.1.4.1941:=CN=Grp1,OU=MonOu,DC=X)
      //
      DirectorySearcher dsLookFor = new DirectorySearcher(deBase);
      dsLookFor.Filter = "(&(memberof:1.2.840.113556.1.4.1941:=CN=Grp1,OU=MonOu,DC=societe,DC=fr)(objectCategory=user))";
      dsLookFor.SearchScope = SearchScope.Subtree;
      dsLookFor.PropertiesToLoad.Add("cn");
    
      SearchResultCollection srcUsers = dsLookFor.FindAll();
    
      // Just to know if user is present in an other group
      foreach (SearchResult srcUser in srcUsers)
      {
        Console.WriteLine("{0}", srcUser.Path);
    
        // To check if a user "user1" is a member of group "group1".
        // Set the base to the user DN (cn=user1, cn=users, dc=x)
        // Set the scope to base
        // Use the following filter :
        // (memberof:1.2.840.113556.1.4.1941:=(cn=Group1,OU=groupsOU,DC=x))
        DirectoryEntry deBaseUsr = new DirectoryEntry(srcUser.Path, "societe\\administrateur", "test.2011");
        DirectorySearcher dsVerify = new DirectorySearcher(deBaseUsr);
        dsVerify.Filter = "(memberof:1.2.840.113556.1.4.1941:=CN=Grp3,OU=MonOu,DC=societe,DC=fr)";
        dsVerify.SearchScope = SearchScope.Base;
        dsVerify.PropertiesToLoad.Add("cn");
    
        SearchResult srcTheUser = dsVerify.FindOne();
    
        if (srcTheUser != null)
        {
          Console.WriteLine("Bingo {0}", srcTheUser.Path);
        }
      }
      Console.ReadLine();
    }
