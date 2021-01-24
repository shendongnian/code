    public static string GetHashedPassword(string plainPassword)
    {
        byte[] passwordBytes = GetBytes(plainPassword);
        // Salt does not need to be a readable string.
        var salt = new byte[] { 7, 122, 17, 8, 253, 45, 73, 72, 0, 165, 33, 44, 13, 104, 88, 92 };
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
