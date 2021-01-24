    public static string Hash(string value)
    {
        if (String.IsNullOrEmpty(value))
            throw new ArgumentNullException(nameof(value));
        var bytes = Encoding.UTF8.GetBytes(value);
        var hash = SHA256.Create().ComputeHash(bytes)
        return Convert.ToBase64String(hash);
    }
