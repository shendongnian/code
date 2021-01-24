    /// <summary>
        /// Get original image
        /// </summary>
        /// <returns></returns>
        public static Image TakeScreen()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            return bitmap;
        }
        /// <summary>
        /// Conver Image to byte array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image value)
        {
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(value, typeof(byte[]));
            return arr;
        }
        /// <summary>
        /// Conver byte array to Image
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] value)
        {
            using(var ms = new MemoryStream(value))
            {
                return Image.FromStream(ms);
            }
        }
        /// <summary>
        /// Convert bytes to base64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string EncodeBytes(byte[] value) => Convert.ToBase64String(value);
        /// <summary>
        /// convert base64 to bytes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] DecodeBytes(string value) => Convert.FromBase64String(value);
        /// <summary>
        /// get MD5 hash from byte array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string StringHash(byte[] value)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(value);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }
