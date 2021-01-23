            public string encryptus(string x, string encrypt)//function
        {
            try
            {
                string y = x;
                byte[] etext = UTF8Encoding.UTF8.GetBytes(y);
                string Code = encrypt;
                MD5CryptoServiceProvider mdhash = new MD5CryptoServiceProvider();
                byte[] keyarray = mdhash.ComputeHash(UTF8Encoding.UTF8.GetBytes(Code));
                TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();
                tds.Key = keyarray;
                tds.Mode = CipherMode.ECB;
                tds.Padding = PaddingMode.PKCS7;
                ICryptoTransform itransform = tds.CreateEncryptor();
                byte[] result = itransform.TransformFinalBlock(etext, 0, etext.Length);
                string encryptresult = Convert.ToBase64String(result);
                return encryptresult.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
            public string dencryptus(string x, string keyai)
        {
            try
            {
                string y = x.Replace("\0", null);
                byte[] etext = Convert.FromBase64String(y);
                string key = keyai;
                MD5CryptoServiceProvider mdhash = new MD5CryptoServiceProvider();
                byte[] keyarray = mdhash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();
                tds.Key = keyarray;
                tds.Mode = CipherMode.ECB;
                tds.Padding = PaddingMode.PKCS7;
                ICryptoTransform itransform = tds.CreateDecryptor();
                byte[] result = itransform.TransformFinalBlock(etext, 0, etext.Length);
                string dencryptresult = UTF8Encoding.UTF8.GetString(result);
                return dencryptresult.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
