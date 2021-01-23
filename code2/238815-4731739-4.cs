    /// Pass in the xml text to sign, along with a hex or Base64-encoded, 160-bit secret key
    public string GenerateSignature(string xml, string secretKey)
    {
      using (HMACSHA1 encoder = new HMACSHA1(secretKey.ToAscii(), true))
      {
        return encoder.ComputeHash(xml.ToUtf8()).ToBase64();
      }
    }
