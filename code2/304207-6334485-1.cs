            //generating data
            int length = 100000;
            byte[] data = new byte[length];
            for (int i = 0; i < length; i++)
            {
                data[i] = System.Convert.ToByte(i % 100 + i % 50);
            }
            byte[] o;
            //serialization into memory stream
            IFormatter formatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, data);
                ms.Seek(0, SeekOrigin.Begin);
                //GZip zip
                using(MemoryStream compressedStream = new MemoryStream())
                {
                    using (var Compress = new GZipStream(compressedStream, CompressionMode.Compress, true))
                    {
                        ms.CopyTo(Compress);
                    }
                    compressedStream.Seek(0, SeekOrigin.Begin);
                    //GZip Unzip
                    using (MemoryStream uncompressedStream = new MemoryStream())
                    {
                        using (var Decompress = new GZipStream(compressedStream, CompressionMode.Decompress, true))
                        {
                            Decompress.CopyTo(uncompressedStream);
                        }
                        uncompressedStream.Seek(0, SeekOrigin.Begin);
                        var oo = formatter.Deserialize(uncompressedStream);
                        o = (byte[])oo;
                    }
                }
                //deserialization from memory stream
                //POINT1
            }
            //checking
            Debug.Assert(data.Length == o.Length);
            for (int i = 0; i < data.Length; i++)
                Debug.Assert(data[i] == o[i]);
