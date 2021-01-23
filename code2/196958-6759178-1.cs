    public static DateTime GetPasswordExpirationDate(string userId, string domainOrMachineName)
    {
        using (var userEntry = new DirectoryEntry("WinNT://" + domainOrMachineName + '/' + userId + ",user"))
        {
            return (DateTime)userEntry.InvokeGet("PasswordExpirationDate");
        }
    }
