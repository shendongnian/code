        public static void Main(string[] args)
        {
            var memStr = new MemoryStream();
            //Write
            var data = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            using (var gzipWr = new GZipStream(memStr, CompressionMode.Compress, true))
                gzipWr.Write(data, 0, data.Length);
            //Read
            var array = new byte[10];
            memStr.Position = 0;
            using (var gzipRd = new GZipStream(memStr, CompressionMode.Decompress))
                gzipRd.Read(array, 0, array.Length); // => res = 10
        }
