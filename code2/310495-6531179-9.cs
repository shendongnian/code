    public static byte[] CreateKey(string password)
    {
        var salt = new byte[] { 1, 2, 23, 234, 37, 48, 134, 63, 248, 4 };
        const int Iterations = 9872;
        using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations))
            return rfc2898DeriveBytes.GetBytes(32);
    }
