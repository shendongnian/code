    public static string sha512Hex(byte[] data)
    {
        using (var alg = SHA512.Create())
        {
            alg.ComputeHash(data);
            return BitConverter.ToString(alg.Hash);
        }
    }
