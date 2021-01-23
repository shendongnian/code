    public static string EncodePassword(string pass, string salt)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(pass);
        byte[] src = Convert.FromBase64String(salt);
        byte[] dst = new byte[src.Length + bytes.Length];
        Buffer.BlockCopy(src, 0, dst, 0, src.Length);
        Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
        HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
        byte[] inArray = algorithm.ComputeHash(dst);
        return Convert.ToBase64String(inArray);
    }
