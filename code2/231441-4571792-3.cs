    static bool VerifyIntegrity(string secret, string checksum, string data)
    {
        // Verify HMAC-SHA256 Checksum
        byte[] key = Encoding.UTF8.GetBytes(secret);
        byte[] value = Encoding.UTF8.GetBytes(data);
        using (var hmac = new HMACSHA256(key))
        {
            return checksum == Convert.ToBase64String(hmac.ComputeHash(value));
        }
    }
