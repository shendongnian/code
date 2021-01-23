           public static string decodeDecompress(string originalReceivedSrc) {
            byte[] bytes = Convert.FromBase64String(originalReceivedSrc);
            using (var mem = new MemoryStream()) {
                //the trick is here
                mem.Write(new byte[] { 0x1f, 0x8b, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00 }, 0, 8);
                mem.Write(bytes, 0, bytes.Length);
                mem.Position = 0;
                using (var gzip = new GZipStream(mem, CompressionMode.Decompress))
                using (var reader = new StreamReader(gzip)) {
                    return reader.ReadToEnd();
                    }
                }
            }
