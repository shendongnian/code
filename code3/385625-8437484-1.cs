    public static bool VerifyData(string originalMessage, string signedMessage, RSAParameters publicKey)
    {
        bool success = false;
        using (var rsa = new RSACryptoServiceProvider())
        {
            //Don't do this, do the same as you did in SignData:
            //byte[] bytesToVerify = Convert.FromBase64String(originalMessage);
            var encoder = new UTF8Encoding();
            byte[] bytesToVerify = encoder.GetBytes(originalMessage);
            byte[] signedBytes = Convert.FromBase64String(signedMessage);
            try
            ...
