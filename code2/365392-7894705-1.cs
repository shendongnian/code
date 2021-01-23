    string LDAP = "LDAP://DC=MYDOMAIN,DC=COM";
    using (DirectoryEntry dirEntry = new DirectoryEntry(LDAP, null, null, AuthenticationTypes.Secure))
        using (DirectorySearcher dirSearch = new DirectorySearcher(
            dirEntry,
            string.Concat("(objectClass=*)"),
            new string[] { "IsraelID" }))
        {
            SearchResult result = dirSearch.FindOne();
            if (result != null)
                return result.Properties["IsraelID"][0].ToString();
            else
                return null;
        }
