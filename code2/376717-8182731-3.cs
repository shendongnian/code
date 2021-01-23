        public static byte[] Compress(byte[] CompressMe)
        {
            MemoryStream ms = null;
            GZipStream gz = null;
            try
            {
                ms = new MemoryStream();
                gz = new GZipStream(ms, CompressionMode.Compress, true);
                gz.Write(CompressMe, 0, CompressMe.Length);
                gz.Flush();
                return ms.ToArray();
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
