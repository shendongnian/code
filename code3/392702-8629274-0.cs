        /// <summary>
        /// Encrypts the specified hash algorithm.
        /// 1. Generates a cryptographic Hash Key for the provided text data.
        /// </summary>
        /// <param name="hashAlgorithm">The hash algorithm.</param>
        /// <param name="dataToHash">The data to hash.</param>
        /// <returns></returns>
        public static string Encrypt(HashAlgorithm hashAlgorithm, string dataToHash)
        {
        
            var tabStringHex = new string[16];
            var UTF8 = new System.Text.UTF8Encoding();
            byte[] data = UTF8.GetBytes(dataToHash);
            byte[] result = hashAlgorithm.ComputeHash(data);
            var hexResult = new StringBuilder(result.Length);
        
            for (int i = 0; i < result.Length; i++)
            {
                //// Convert to hexadecimal
                hexResult.Append(result[i].ToString("X2"));
            }
            
    
    return hexResult.ToString();
    }
    /// <summary>
    /// Determines whether [is hash match] [the specified hash algorithm].
    /// </summary>
    /// <param name="hashAlgorithm">The hash algorithm.</param>
    /// <param name="hashedText">The hashed text.</param>
    /// <param name="unhashedText">The unhashed text.</param>
    /// <returns>
    ///   <c>true</c> if [is hash match] [the specified hash algorithm]; 
    /// otherwise, <c>false</c>.
    /// </returns>
    public static bool IsHashMatch(HashAlgorithm hashAlgorithm,
        string hashedText, string unhashedText)
    {
        string hashedTextToCompare = Encrypt(
            hashAlgorithm, unhashedText);
        return (String.Compare(hashedText,
            hashedTextToCompare, false) == 0);
    }
