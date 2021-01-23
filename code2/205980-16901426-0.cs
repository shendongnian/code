        private static void SplitFile(string inputFile, int chunkSize, string path)
        {
            byte[] buffer = new byte[chunkSize];
            List<byte> extraBuffer = new List<byte>();
            using (Stream input = File.OpenRead(inputFile))
            {
                int index = 0;
                while (input.Position < input.Length)
                {
                    using (Stream output = File.Create(path + "\\" + index + ".csv"))
                    {
                        int chunkBytesRead = 0;
                        while (chunkBytesRead < chunkSize)
                        {
                            int bytesRead = input.Read(buffer,
                                                       chunkBytesRead,
                                                       chunkSize - chunkBytesRead);
                            if (bytesRead == 0)
                            {
                                break;
                            }
                            chunkBytesRead += bytesRead;
                        }
                        byte extraByte = buffer[chunkSize - 1];
                        while (extraByte != '\n')
                        {
                            int flag = input.ReadByte();
                            if (flag == -1)
                                break;
                            extraByte = (byte)flag;
                            extraBuffer.Add(extraByte);
                        }
                        output.Write(buffer, 0, chunkBytesRead);
                        if (extraBuffer.Count > 0)
                            output.Write(extraBuffer.ToArray(), 0, extraBuffer.Count);
                        
                        extraBuffer.Clear();
                    }
                    index++;
                }
            }
        }
