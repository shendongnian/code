       public static string HashStringSha1(string plainText, string salt)
            {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
                {
                    byte[] bb = sha1.ComputeHash(Encoding.UTF8.GetBytes(salt + plainText + plainText));
                    return Convert.ToBase64String(bb);
                }
            }
