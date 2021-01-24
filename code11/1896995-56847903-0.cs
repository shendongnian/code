     using (System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider())
     {
         System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();
         byte[] data = md5.ComputeHash(utf8.GetBytes(input));
         return Convert.ToBase64String(data);
     }
