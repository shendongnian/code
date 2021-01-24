    private static byte[] ConvertPKCS1PemToDer(string pemContents)
    {
        return Convert.FromBase64String(pemContents
            .TrimStart("-----BEGIN RSA PRIVATE KEY-----".ToCharArray())
            .TrimEnd("-----END RSA PRIVATE KEY-----".ToCharArray())
            .Replace("\r\n",""));
    }
