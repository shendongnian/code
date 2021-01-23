    public static string ComputeHash(string fileName, HashAlgorithm hashAlgorithm)
    {
        string hashFixed = null;
        try
        {
            using (FileStream stmcheck = File.OpenRead(fileName))
            {
                try
                {
                    byte[] hash = hashAlgorithm.ComputeHash(stmcheck);
                    hashFixed = BitConverter.ToString(hash).Replace("-", "");
                }
                catch
                {
                    //logging as needed
                }
                finally
                {
                    stmcheck.Close();
                }
            }
        }
        catch
        {
            //logging as needed
        }
        return hashFixed;
    }
