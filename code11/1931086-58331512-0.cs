    using (var ss = new FileStream("log.txt.gz", FileMode.Open))
            using (var ms = new MemoryStream())
            {
                using (var gZipStream = new GZipStream(ss, CompressionMode.Decompress))
                {
                    gZipStream.CopyTo(ms);
                }
                ms.Seek(0, SeekOrigin.Begin);  // so I put the stream to the initial position
                using (var sr = new StreamReader(ms, Encoding.UTF8))
                {
                    var text = sr.ReadToEnd();
                }
            }
