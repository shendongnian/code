    PrincipalContext context = new PrincipalContext(ContextType.Domain, "mydomain");
    var domainUsers = new List<string>();
    var userPrincipal = new UserPrincipal(context);
    string myCompany = "Test123";
    using (var search = new PrincipalSearcher(userPrincipal))
    {
        foreach (Principal user in search.FindAll())
        {
            string usersCompany = ((DirectoryEntry)user.GetUnderlyingObject())?.Properties["company"]?.Value?.ToString();
            if (user.DisplayName != null && usersCompany != null && usersCompany.Equals(myCompany))
            {
                domainUsers.Add(user.DisplayName);
            }
        }
    }
**EDIT**
For performance reason, I would recommend using `DirectorySearcher` instead of using `PrincipalSearcher`. Here is the other version. Search is done before the `FindAll()` is executed.
    string myCompany = "Test123";
    string searchQuery = $"(&(objectCategory=user)(objectClass=user)(company={myCompany}))";
    DirectorySearcher ds = new DirectorySearcher(searchQuery);
    foreach(SearchResult user in ds.FindAll())
    {
        domainUsers.Add(user.GetDirectoryEntry().Properties["DisplayName"].Value.ToString());
    }
