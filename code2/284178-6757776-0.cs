    DirectorySearcher objDirSearch = new DirectorySearcher(SearchRoot);
    DirectoryEntry dentUser = null;
    string pstrFieldName, pstrValue;
    
    pstrFieldName = "company";
    pstrValue = "12345"; //Employee number
    
    /*setting the filter as per the employee number*/
    objDirSearch.Filter = "(&(objectClass=user)(" + pstrFieldName + "=" + pstrValue + "))";
    
    SearchResult objResults = objDirectorySearch.FindOne();
    
    dentUser = new DirectoryEntry(objResults.Path);}
    
    string strManager = dentUser.Properties["manager"].Value.ToString();
    
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.DistinguishedName, strManager);
    
    string strManagerMailID = user.EmailAddress; 
