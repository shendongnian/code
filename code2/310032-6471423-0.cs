        static void Main(string[] args)
        {
            var content = @"someTextOrXMLContentGoesHereCanBeAnything#$&%&*(@#$^";
            var data = Encoding.UTF8.GetBytes(content.ToCharArray());
            var fs = new StreamWriter(@"c:\users\stackoverflow\desktop\sample.bin");
            using (var bw = new BinaryWriter(fs.BaseStream))
            {
                using (var ms = new MemoryStream())
                {
                    using (var compress = new GZipStream(ms, CompressionMode.Compress, true))
                    {
                        compress.Write(data, 0, data.Length);
                    }
                    // encrypt goes here
                    var compressedData = ms.ToArray();
                    Console.WriteLine(compressedData.Length); // 179
                    bw.Write(compressedData);
                }
            }
            // and the reverse...
            using (var fs2 = new StreamReader(@"c:\users\stackoverflow\desktop\sample.bin"))
            {
                using (var br = new BinaryReader(fs2.BaseStream))
                {
                    var len = (int)br.BaseStream.Length;
                    var encrypted = br.ReadBytes(len);
                    // decrypt here
                    var decrypted = encrypted; // <== new result after decryption
                    using (var ms = new MemoryStream(decrypted))
                    {
                        List<byte> bytesList = new List<byte>();
                        using (var decompress = new GZipStream(ms, CompressionMode.Decompress, true))
                        {
                            int val = decompress.ReadByte();
                            while (val > -1)
                            {
                                bytesList.Add((byte)val);
                                val = decompress.ReadByte();
                            }  
                        }
                        var final_result = new String(Encoding.UTF8.GetChars(bytesList.ToArray()));
                        Console.WriteLine(final_result);
                    }
                }
            }
            Console.ReadLine();
        }
