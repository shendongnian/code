        /// <summary>
        /// Creates a Guid which is guaranteed not to equal the empty Guid.
        /// </summary>
        /// <returns>A string</returns>
        public static string CreateGuid()
        {
            Guid guid = Guid.Empty;
            while (Guid.Empty == guid)
            {
                guid = Guid.NewGuid();
            }
            // Uses base64 encoding the guid.(Or  ASCII85 encoded)
            // But not recommend using Hex, due to it is inefficient.
            string key = Convert.ToBase64String(guid.ToByteArray);
            return key;
        }
