    DirectoryEntry de = null; 
    SearchResult results = null; 
    de = new DirectoryEntry(); 
 
    // Assuming your domain dns name is treyresearch.net 
    de.Path = "LDAP://servername/CN=users,DC=treyresearch,DC=net"; 
    de.AuthenticationType = AuthenticationTypes.Secure; 
    de.Username = "treyresearch\\Administrator";
    de.Password = "P@$$W0rd";
    DirectorySearcher search = new DirectorySearcher(de); 
    search.Filter = string.Format("(objectClass={0})",'*'); 
    search.PropertiesToLoad.Add("IsraelID"); 
    results = search.FindOne(); 
    de = results.GetDirectoryEntry(); 
