    var bytes = new byte[8];
    using (var rng = new RNGCryptoServiceProvider())
    {
        rng.GetBytes(bytes);
    }
    
    Console.WriteLine(BitConverter.ToInt64(bytes, 0));
