        private static byte[] Compress(Stream stream)
        {
            using (var resultStream = new MemoryStream())
            {
                using (var gzipStream = new DeflateStream(resultStream, CompressionMode.Compress))
                    stream.CopyTo(gzipStream);
                return resultStream.ToArray();
            }
        }
        private static byte[] Decompress(byte[] bytes)
        {
            using (var readStream = new MemoryStream(bytes))
            using (var resultStream = new MemoryStream())
            {
                using (var gzipStream = new DeflateStream(readStream, CompressionMode.Decompress))
                    gzipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }
