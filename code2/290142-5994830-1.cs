    static byte[] Sha256HashFile(string file)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            using (Stream input = File.OpenRead(file))
            {
                return sha256.ComputeHash(input);
            }
        }
    }
