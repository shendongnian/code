    public static class StringCompression
    {
        /// <summary>
        /// Compresses a string and returns a deflate compressed, Base64 encoded string.
        /// </summary>
        /// <param name="uncompressedString">String to compress</param>
        public static string CompressString(string uncompressedString)
        {
            byte[] compressedBytes;
            using (var compressedStream = new MemoryStream())
            {
                using (var uncompressedStream = new MemoryStream(Encoding.UTF8.GetBytes(uncompressedString)))
                {
                    using (var compressorStream = new DeflateStream(compressedStream, CompressionLevel.Fastest))
                    {
                        uncompressedStream.CopyTo(compressorStream);
                    }
                }
                compressedBytes = compressedStream.ToArray();
            }
            return Convert.ToBase64String(compressedBytes);
        }
        /// <summary>
        /// Decompresses a deflate compressed, Base64 encoded string and returns an uncompressed string.
        /// </summary>
        /// <param name="compressedString">String to decompress.</param>
        public static string DecompressString(string compressedString)
        {
            byte[] decompressedBytes;
            using (var decompressedStream = new MemoryStream())
            {
                using (var compressedStream = new MemoryStream(Convert.FromBase64String(compressedString)))
                {
                    using (var decompressorStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
                    {
                        decompressorStream.CopyTo(decompressedStream);
                    }
                }
                decompressedBytes = decompressedStream.ToArray();
            }
            return Encoding.UTF8.GetString(decompressedBytes);
        }
    }
