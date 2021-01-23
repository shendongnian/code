    public void ChangeMyPassword(string domainName, string userName, string currentPassword, string newPassword)
    {
        try
        {
            string ldapPath = "LDAP://192.168.1.xx";
            DirectoryEntry directionEntry = new DirectoryEntry(ldapPath, domainName + "\\" + userName, currentPassword);
            if (directionEntry != null)
            {
                DirectorySearcher search = new DirectorySearcher(directionEntry);
                search.Filter = "(SAMAccountName=" + userName + ")";
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    DirectoryEntry userEntry = result.GetDirectoryEntry();
                    if (userEntry != null)
                    {
                        userEntry.Invoke("ChangePassword", new object[] { currentPassword, newPassword });
                        userEntry.CommitChanges();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
