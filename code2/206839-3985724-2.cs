    public static string Hash(string value)
    {
       var sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
       byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(value));
       return BytesToHex(hash).ToLower();
    }
    private static string BytesToHex(byte[] bytes)
    {
       return String.Concat(Array.ConvertAll(bytes, x => x.ToString("X2")));
    }
