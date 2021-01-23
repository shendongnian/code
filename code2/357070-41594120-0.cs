    DirectoryEntry group = new DirectoryEntry("LDAP://CN=Sales,DC=Fabrikam,DC=COM");
    DirectorySearcher groupMember = new DirectorySearcher
        (group,"(objectClass=*)",new string[]{"member;Range=0-500"},SearchScope.Base);
    SearchResult result = groupMember.FindOne();
    // Each entry contains a property name and the path (ADsPath).
    // The following code returns the property name from the PropertyCollection. 
    String propName=String.Empty;
    foreach(string s in result.Properties.PropertyNames)
    {
        if ( s.ToLower() != "adspath")
        {
          propName = s;
          break;
        }
    }
    foreach(string member in result.Properties[propName])
    {
         Console.WriteLine(member);
    }
