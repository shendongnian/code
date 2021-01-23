    public static string Compress(this string s)
        {
            byte[] bytesToEncode = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(bytesToEncode.Compress());
        }
        public static byte[] Compress(this byte[] bytesToEncode)
        {
            using (MemoryStream input = new MemoryStream(bytesToEncode))
            using (MemoryStream output = new MemoryStream())
            {
                using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(output, System.IO.Compression.CompressionMode.Compress))
                {
                    input.CopyTo(zip);
                }
                return output.ToArray();
            }
        }
        public static string Explode(this string s)
        {
            byte[] compressedBytes = Convert.FromBase64String(s);
            return Encoding.UTF8.GetString(compressedBytes.Explode());
        }
        public static byte[] Explode(this byte[] compressedBytes)
        {
            using (MemoryStream input = new MemoryStream(compressedBytes))
            using (MemoryStream output = new MemoryStream())
            {
                using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(input, System.IO.Compression.CompressionMode.Decompress))
                {
                    zip.CopyTo(output);
                }
                return output.ToArray();
            }
        }
