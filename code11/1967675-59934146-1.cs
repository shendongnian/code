    PrincipalContext context = new PrincipalContext(ContextType.Domain, "denbighshire.gov.uk");
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
