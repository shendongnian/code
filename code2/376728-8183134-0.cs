        public static byte[] Compress(byte[] CompressMe)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                return Compress(CompressMe, ms);
            }
        }
        public static byte[] Compress(byte[] CompressMe, MemoryStream ms)
        {
            using (GZipStream gz = new GZipStream(ms, CompressionMode.Compress, true))
            {
                gz.Write(CompressMe, 0, CompressMe.Length);
                ms.Position = 0;
                byte[] Result = new byte[ms.Length];
                ms.Read(Result, 0, (int)ms.Length);
                return Result;
            }
        }
