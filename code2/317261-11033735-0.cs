    try
    {
    DirectoryEntry entry = new DirectoryEntry("LDAP://" + userDomain, userName, password, AuthenticationTypes.Secure);
    if (IsDomainAdmin(entry, userName))
    {
    string fullUserName = userDomain + @"\" + userName;
    Console.WriteLine("user is administrator : " + fullUserName);
    //PrincipalContext context = new PrincipalContext(
    // ContextType.Domain, userDomain);
    //if (context.ValidateCredentials(fullUserName, password))
    //{
    // Console.WriteLine("Success!");
    //}
    }
    else
    Console.WriteLine("user is not administrator");
    }
    catch(Exception ex)
    {
    Console.WriteLine("invalid username or password, can't authenticate");
    }
    Console.ReadLine();
    }
    
    public static bool IsDomainAdmin(DirectoryEntry entry, string userName)
    {
    string adminDn = GetAdminDn(entry);
    if (!isUserFound(entry, adminDn, userName))
    {
    string adUser = GetAdministratorsDN(entry);
    return isUserFound(entry, adUser, userName);
    }
    return true;
    }
    
    private static bool isUserFound(DirectoryEntry entry, string adminDN, string userName)
    {
    SearchResult result = (new DirectorySearcher(
    entry,
    "(&(objectCategory=user)(samAccountName=" + userName + "))",
    new[] { "memberOf" })).FindOne();
    return result.Properties["memberOf"].Contains(adminDN);
    }
    
    public static string GetAdminDn(DirectoryEntry entry)
    {
    return (string)(new DirectorySearcher(
    entry,
    "(&(objectCategory=group)(cn=Domain Admins))")
    .FindOne().Properties["distinguishedname"][0]);
    }
    
    public static string GetAdministratorsDN(DirectoryEntry entry)
    {
    return (string)(new DirectorySearcher(
    entry,
    "(&(objectCategory=group)(cn=Administrators))")
    .FindOne().Properties["distinguishedname"][0]);
    }
    }
