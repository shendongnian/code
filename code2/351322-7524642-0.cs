    public bool Authenticate(AccountDataContext context)
    {
        var password = context.UserAccounts.FirstOrDefault(p => p.UserAccountUID == UserAccountUID).Password;
        var hash = Hash(password); //lower case password, not Password.
        return password.Equals(hash);
    }
