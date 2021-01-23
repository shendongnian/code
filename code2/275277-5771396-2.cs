    public byte [] GenerateSalt()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            var salt = new byte[16];
            rng.GetBytes(salt);
            return salt;
        }
    }
