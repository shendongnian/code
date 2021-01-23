        public static byte[] Compress(byte[] CompressMe)
        {
            MemoryStream ms = null;
            GZipStream gz = null;
            try
            {
                ms = new MemoryStream();
                gz = new GZipStream(ms, CompressionMode.Compress, true);
                gz.Write(CompressMe, 0, CompressMe.Length);
                ms.Position = 0;
                byte[] Result = new byte[ms.Length];
                ms.Read(Result, 0, (int)ms.Length);
                return Result;
            }
            finally
            {
                if (gz != null)
                {
                    gz.Dispose();
                }
                else if (ms != null)
                {
                    ms.Dispose();
                }
            }
        }
