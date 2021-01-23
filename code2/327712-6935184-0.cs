    public static string GetMD5Base64Hash(string strToHash)
    {
        byte[] byteStr = Encoding.UTF8.GetBytes(strToHash);
        byte[] hashVal = (new System.Security.Cryptography.MD5CryptoServiceProvider()).ComputeHash(byteStr);
        string base64Hash = Convert.ToBase64String(hashVal);
        return base64Hash;
    }
