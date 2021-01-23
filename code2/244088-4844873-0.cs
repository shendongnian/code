     public static string GetHashValue(string sourceString)
     {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider()
        byte[] hashData = provider.ComputeHash(Encoding.UTF8.GetBytes(sourceString));
 
        int i;
        StringBuilder sOutput = new StringBuilder(hashData.Length);
        for (i=0;i < hashData.Length;         
        {
            sOutput.Append(hashData[i].ToString("X2"));
        }
        return sOutput.ToString();
     }
