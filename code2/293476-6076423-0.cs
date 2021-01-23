    string fi = @"C:\Path To Compressed File";
        // Get the stream of the source file.
               //     using (FileStream inFile = fi.OpenRead())
                    using (MemoryStream infile1 = new MemoryStream(File.ReadAllBytes(fi)))
                    {
        
                        //Create the decompressed file.
                        string outfile = @"C:\Decompressed.exe";
                        {
                            using (GZipStream Decompress = new GZipStream(infile1,
                                    CompressionMode.Decompress))
                            {
                                byte[] b = new byte[blen.Length];
                                Decompress.Read(b,0,b.Length);
                                File.WriteAllBytes(outfile, b);
                            }
                        }
                    }
