    static bool VerifyIntegrity(string secret, string checksum, string data)
    {
        // Verify HMAC-SHA256 Checksum
        byte[] key = Encoding.UTF8.GetBytes(secret);
        byte[] value = Encoding.UTF8.GetBytes(data);
        byte[] checksumBytes = Convert.FromBase64String(checksum);
        using (var hmac = new HMACSHA256(key))
        {
            byte[] expectedBytes = hmac.ComputeHash(value);
            return checksumBytes.SequenceEqual(expectedBytes);
        }
    }
