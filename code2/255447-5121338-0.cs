    public static string EncryptToMD5(this string helper)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                return BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(helper)));
            }
