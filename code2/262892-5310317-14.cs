    public string GetDepartment(string username)
    {
        string result = string.Empty;
        // if you do repeated domain access, you might want to do this *once* outside this method, 
        // and pass it in as a second parameter!
        PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);
        // find the user
        UserPrincipal user = UserPrincipal.FindByIdentity(yourDomain, username);
        // if user is found
        if(user != null)
        {
           // get DirectoryEntry underlying it
           DirectoryEntry de = (user.GetUnderlyingObject() as DirectoryEntry);
           if (de != null)
           {
              if (de.Properties.Contains("department"))
              {
                 result = de.Properties["department"][0].ToString();
              }
           }
        }
 
        return result;
    }
