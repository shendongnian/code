        public static byte[] Decompress(byte[] bSource)
        {
            try
            {
                using (var instream = new MemoryStream(bSource))
                {
                    using (var gzip = new GZipStream(instream, CompressionMode.Decompress))
                    {
                        using (var outstream = new MemoryStream())
                        {
                            byte[] buffer = new byte[4096];
                            while (true)
                            {
                                int delta = gzip.Read(buffer, 0, buffer.Length);
                                if (delta > 0)
                                    outstream.Write(buffer, 0, delta);
                                
                                if (delta < 4096)
                                    break;
                            }
                            return outstream.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error decompressing byte array", ex);
            }
        }
