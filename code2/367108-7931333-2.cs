        public static string CalcHashCode(string filename)
        {
            FileStream stream = new FileStream(
                filename,
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read,
                System.IO.FileShare.ReadWrite);
            try
            {
                return CalcHashCode(stream);
            }
            finally
            {
                stream.Close();
            }
        }
        public static string CalcHashCode(FileStream file)
        {
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            Byte[] hash = md5Provider.ComputeHash(file);
            return Convert.ToBase64String(hash);
        }
