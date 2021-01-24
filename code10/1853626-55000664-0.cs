     public string MD5Hash(string input)
        {
            System.Security.Cryptography.SHA512Managed sha512 = new System.Security.Cryptography.SHA512Managed();
            Byte[] EncryptedSHA512 = sha512.ComputeHash(System.Text.Encoding.UTF8.GetBytes(string.Concat(input, securityCode)));
            sha512.Clear();
            return Convert.ToBase64String(EncryptedSHA512);
        }
