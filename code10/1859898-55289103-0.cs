    var groupSearch = new DirectorySearcher(
        new DirectoryEntry("LDAP://OU=Groupes,OU=CR 1,DC=zcam,DC=ztech"), //notice the OU
        "(objectClass=group)");
    
    //if you don't do this, it will return *every* attribute, which is slower
    groupSearch.PropertiesToLoad.Add("distinguishedName");
    
    //build a user query with all the groups
    var userFilter = new StringBuilder("(&(objectClass=user)(|");
    using (var results = groupSearch.FindAll()) {
        foreach (SearchResult result in results) {
            userFilter.Append($"(memberOf={result.Properties["distinguishedName"][0]})");
        }
    }
    userFilter.Append(")");
    
    var userSearch = new DirectorySearcher(
        new DirectoryEntry("LDAP://DC=zcam,DC=ztech"),
        userFilter.ToString());
    
    //userSearch.PropertiesToLoad.Add(""); //add only the attributes you need to make it quicker
    
    using (var results = userSearch.FindAll()) {
        foreach (SearchResult result in results) {
            //do something
        }
    }
