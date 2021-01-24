    public static string GetHashedPassword(string plainPassword, byte[] salt)
    {
        byte[] passwordBytes = GetBytes(plainPassword);
        // Merge the password bytes and the salt bytes
        var mergedBytes = new byte[passwordBytes.Length + salt.Length];
        Array.Copy(passwordBytes, mergedBytes, passwordBytes.Length);
        Array.Copy(salt, 0, mergedBytes, passwordBytes.Length, salt.Length);
        // Now hash password + salt
        byte[] hash;
        using (var sha = SHA256.Create()) {
            hash = sha.ComputeHash(mergedBytes);
        }
        return Base64Encode(hash);
    }
