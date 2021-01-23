    using System.DirectoryServices;
    
    
    private DirectoryEntry GetUser(string UserName)
    
    {
    
        DirectoryEntry de = GetDirectoryObject();
        DirectorySearcher deSearch = new DirectorySearcher();
        deSearch.SearchRoot = de;
    
        deSearch.Filter = "(&(objectClass=user)(SAMAccountName=" + UserName + "))";
        deSearch.SearchScope = SearchScope.Subtree;
        SearchResult results = deSearch.FindOne();
    
        if (!(results == null))
        {
           // **THIS IS THE MOST IMPORTANT LINE**
           de = new DirectoryEntry(results.Path, "username", "password", AuthenticationTypes.Secure); 
           return de;
        }
        else
        {
           return null;
        }
    }
    
    private DirectoryEntry GetDirectoryObject()
    
    {
    
        DirectoryEntry oDE;
        oDE = new DirectoryEntry("LDAP://192.168.1.101", "username", "password", AuthenticationTypes.Secure);
        return oDE;
    }
    
    
     public static bool ChangePassword(string UserName, string strOldPassword, string strNewPassword)
    
            {
    
                bool passwordChanged = false;
    
                DirectoryEntry oDE = GetUser(UserName, strOldPassword);
    
                if (oDE != null)
                {
                    try
                    {
                        // Change the password.
                        oDE.Invoke("ChangePassword", new object[] { strOldPassword, strNewPassword });
                        passwordChanged = true;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error changing password. Reason: " + ex.Message);
    
                    }
                }
                return passwordChanged;
            }
