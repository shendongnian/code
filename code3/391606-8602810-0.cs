        public static string ReadEndTokens(string filename, Int64 numberOfTokens, Encoding encoding, string tokenSeparator)
        {
            lock (typeof(SDAccess))
            {
                PersistentStorage sdPS = new PersistentStorage("SD");
                sdPS.MountFileSystem();
                string rootDirectory = VolumeInfo.GetVolumes()[0].RootDirectory;
                int sizeOfChar = 1;//The only encoding suppourted by NETMF4.1 is UTF8
                byte[] buffer = encoding.GetBytes(tokenSeparator);
                using (FileStream fs = new FileStream(rootDirectory + @"\" + filename, FileMode.Open, FileAccess.ReadWrite))
                {
                    Int64 tokenCount = 0;
                    Int64 endPosition = fs.Length / sizeOfChar;
                    for (Int64 position = sizeOfChar; position < endPosition; position += sizeOfChar)
                    {
                        fs.Seek(-position, SeekOrigin.End);
                        fs.Read(buffer, 0, buffer.Length);
                        encoding.GetChars(buffer);
                        if (encoding.GetChars(buffer)[0].ToString() + encoding.GetChars(buffer)[1].ToString() == tokenSeparator)
                        {
                            tokenCount++;
                            if (tokenCount == numberOfTokens)
                            {
                                byte[] returnBuffer = new byte[fs.Length - fs.Position];
                                fs.Read(returnBuffer, 0, returnBuffer.Length);                          
                                sdPS.UnmountFileSystem();// Unmount file system
                                sdPS.Dispose();
                                return GetString(returnBuffer);
                            }
                        }
                    }
                    // handle case where number of tokens in file is less than numberOfTokens
                    fs.Seek(0, SeekOrigin.Begin);
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    sdPS.UnmountFileSystem();// Unmount file system
                    sdPS.Dispose();
                    return GetString(buffer);
                }
            }
        }
        //As GetString is not implemented in NETMF4.1 I've done this method
        public static string GetString(byte[] bytes)
        {
            string cadena = "";
            for (int i = 0; i < bytes.Length; i++)
                cadena += Encoding.UTF8.GetChars(bytes)[i].ToString();
            return cadena;
        }
