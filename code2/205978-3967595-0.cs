    public static void SplitFile(string inputFile, int chunkSize, string path)
    {
        const int BUFFER_SIZE = 20 * 1024;
        byte[] buffer = new byte[BUFFER_SIZE];
        using (Stream input = File.OpenRead(inputFile))
        {
            int index = 0;
            while (input.Position < input.Length)
            {
                using (Stream output = File.Create(path + "\\" + index))
                {
                    int chunkBytesRead = 0;
                    while (chunkBytesRead < chunkSize)
                    {
                        int bytesRead = input.Read(buffer, 0,
                            Math.Min(chunkSize - chunkBytesRead, BUFFER_SIZE));
                        if (bytesRead <= 0)
                        {
                            break;
                        }
                        output.Write(buffer, 0, bytesRead);
                        chunkBytesRead += bytesRead;
                    }
                }
                index++;
                Thread.Sleep(500); // experimental; perhaps try it
            }
        }
    }
