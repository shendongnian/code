       /// <summary>
    /// This is a utility class that can be used to securely hash and verify a password.
    /// The output from the Hashing process includes a header to identify that the value
    /// has been produced using this code, the salt value used to produce the has and the hash value
    /// itself.
    /// Note: the salt value is randomly produced for each hashed password.
    /// </summary>
    public static class PasswordHashUtility
    {
        /// <summary>
        /// Size of salt for Hash production
        /// </summary>
        private const int SaltSize = 16;
        /// <summary>
        /// Size of Has
        /// </summary>
        private const int HashSize = 20;
        private const string HashType = "$MBnYt1!?$V1";
        public static int HashIterations = 1000;
        /// <summary>
        /// Creates a hash from a password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="iterations">Number of iterations.</param>
        /// <returns>The hash</returns>
        public static string Hash(string password, int iterations)
        {
            // Create salt
            var salt = new byte[SaltSize];
            var cryptoServiceProvider = new RNGCryptoServiceProvider();
            cryptoServiceProvider.GetBytes(salt);
            // Create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);
            // Combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
            // Convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);
            // tidy-up 
            cryptoServiceProvider.Dispose();
            pbkdf2.Dispose();
            // Format hash with extra information
            return $"{HashType}{iterations}${base64Hash}";
        }
        /// <summary>
        /// Checks if hash has been produced by this utility.
        /// </summary>
        /// <param name="hashString">The hash type name</param>
        /// <returns>True if supported</returns>
        public static bool IsHashSupported(string hashString)
        {
            return hashString.StartsWith(HashType);
        }
        /// <summary>
        /// Verifies a password against a hash.
        /// </summary>
        /// <param name="password">The password to verify</param>
        /// <param name="hashedPassword">The hash value to verify against</param>
        /// <returns>Could be verified?</returns>
        public static bool Verify(string password, string hashedPassword)
        {
            // Check hash
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hash type is not supported");
            }
            // Extract iteration and Base64 string
            var splitHashString = hashedPassword.Replace(HashType, "").Split('$');
            var iterations = int.Parse(splitHashString[0]);
            var base64Hash = splitHashString[1];
            // Get hash bytes
            var hashBytes = Convert.FromBase64String(base64Hash);
            // Get salt
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            // Create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);
            //tidy-up
            pbkdf2.Dispose();
            // Get result
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
