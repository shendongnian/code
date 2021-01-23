    public static string ComputeHash(string fileName, HashAlgorithm hashAlgorithm)
    {
        string hashFixed;
        try
        {
            FileStream stmcheck = File.OpenRead(fileName);
            try
            {
                byte[] hash = hashAlgorithm.ComputeHash(stmcheck);
                hashFixed = BitConverter.ToString(hash).Replace("-", "");
            }
            finally
            {
                stmcheck.Close();
            }
        }
        catch
        {
            hashFixed = null;
        }
        return hashFixed;
    }
