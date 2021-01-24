    private string CreateJwtToken()
    {
        var header = ...;
        var payload = ...;
        using (ECDsa key = ECDsa.Create())
        {
            key.ImportPkcs8PrivateKey(Convert.FromBase64String(p8privateKey), out _);
            string headerBase64 = ...;
            string payloadBase64 = ...;
            string unsignedJwtData = ...;
            byte[] encodedRequest = Encoding.UTF8.GetBytes(unsignedJwtData);
            byte[] signature = key.SignData(encodedRequest, HashAlgorithmName.SHA256);
            return $"{unsignedJwtData}.{Convert.ToBase64String(signature)}";
        }
    }
