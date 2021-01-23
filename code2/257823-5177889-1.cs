            string secretKey = "MySecretKey";
            string salt = "123";
            System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();
            byte[] preHash = System.Text.Encoding.UTF32.GetBytes(secretKey + salt);
            byte[] hash = sha.ComputeHash(preHash);
            string password = System.Convert.ToBase64String(hash);
