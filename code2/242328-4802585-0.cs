    /// <summary>
    /// Calculates SHA1 hash
    /// </summary>
    /// <param name="text">input string</param>
    /// <param name="enc">Character encoding</param>
    /// <returns>SHA1 hash</returns>
    public static string CalculateSHA1(string text, Encoding enc)
    {
        byte[] buffer = enc.GetBytes(text);
        SHA1CryptoServiceProvider cryptoTransformSHA1 = 
        new SHA1CryptoServiceProvider();
        string hash = BitConverter.ToString(
            cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        return hash;
    }
