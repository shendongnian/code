    public static string Cryptography(string plainText, string publicKeyStringBase64)
    {
        var publicKey = Convert.FromBase64String(publicKeyStringBase64);
        var publicKeyRaw = Encoding.UTF8.GetString(publicKey);
        var rsaInfo = GetRSAParametersFromPublicKey(publicKeyRaw);
        if (rsaInfo.Modulus != null && rsaInfo.Exponent != null)
        {
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaInfo);
            var hash = csp.Encrypt(Encoding.Unicode.GetBytes(plainText), false);
            var encryptedText = HttpUtility.UrlEncode(Convert.ToBase64String(hash));
          
            return encryptedText;
        }
        return "!!error!!";
    }
