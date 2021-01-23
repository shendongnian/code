    public void MyAction() {
        string signature = request.Headers["X-Hub-Signature"];
        request.InputStream.Position = 0;
        StreamReader reader = new StreamReader(request.InputStream);
        string json = reader.ReadToEnd();
        var hmac = SignWithHmac(UTF8Encoding.UTF8.GetBytes(json), UTF8Encoding.UTF8.GetBytes("MySecret"));
        var hmacHex = ConvertToHexadecimal(hmac);
        bool isValid = signature.Split('=')[1] == hmacHex ;
    }
    private static byte[] SignWithHmac(byte[] dataToSign, byte[] keyBody) {
        using (var hmacAlgorithm = new System.Security.Cryptography.HMACSHA1(keyBody)) {
            return hmacAlgorithm.ComputeHash(dataToSign);
        }
    }
    private static string ConvertToHexadecimal(IEnumerable<byte> bytes)
    {
        var builder = new StringBuilder();
        foreach (var b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }
        return builder.ToString();
     }
