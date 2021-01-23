            using(var memory = new MemoryStream())
            {
                using(var gzip = new GZipStream(memory, CompressionMode.Compress, true))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(gzip, ds);
                }
                return memory.ToArray();
            }
