    public void DeleteOU (string ldap, string filterOU)
    {
        // ldap = "LDAP://DC=fabri,DC=com"
        // filteredOU = "OU=OUName" or "CN=OUName" depending on how its configured.
        DirectoryEntry root = new DirectoryEntry(ldap);
        DirectorySearcher searcher = new DirectorySearcher(root);
        searcher.Filter = $"(&(objectCategory=organizationalUnit)({filterOU}))";
        try
        {
            foreach (SearchResult res in searcher.FindAll())
            {
                DirectoryEntry thisOU = res.GetDirectoryEntry();
                thisOU.DeleteTree();
                thisOU.CommitChanges();
            }
        }
        catch (Exception ex)
        {
            // do something with exception. Most likely, Not Found.
        }
    }
