    var bytes = new byte[16];
    using (var rng = new RNGCryptoServiceProvider())
    {
        rng.GetBytes(bytes);
    }
    // and if you need it as a string...
    string hash1 = BitConverter.ToString(bytes);
    // or maybe...
    string hash2 = BitConverter.ToString(bytes).Replace("-", "").ToLower();
