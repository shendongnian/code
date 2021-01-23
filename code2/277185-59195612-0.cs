        public static string SHA512Hash(string value)
        {
            byte[] encryptedBytes;
            
            using (var hashTool = new SHA512Managed())
            {
                encryptedBytes = hashTool.ComputeHash(System.Text.Encoding.UTF8.GetBytes(string.Concat(value)));
                hashTool.Clear();
            }
            return Convert.ToBase64String(encryptedBytes);
        }
