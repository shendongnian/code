    public static string Encode(string original)
    {
        byte[] encodedBytes;
        using (var md5 = new MD5CryptoServiceProvider())
        {
            var originalBytes = Encoding.Default.GetBytes(original);
            encodedBytes = md5.ComputeHash(originalBytes);
        }
        StringBuilder hash = new StringBuilder();
        for (int i = 0; i < encodedBytes.Length; i++)
        {
            hash.Append(encodedBytes[i].ToString("X2"));
        }
        return hash.ToString();
    }
