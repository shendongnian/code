    public static string GenerateRandomSalt(RNGCryptoServiceProvider rng, int size)
    {
        var bytes = new Byte[size];
        rng.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
    var rng = new RNGCryptoServiceProvider();
    var salt1 = GenerateRandomSalt(rng, 16);
    var salt2 = GenerateRandomSalt(rng, 16);
    // etc.
