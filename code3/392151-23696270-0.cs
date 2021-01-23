    private const int READ_BUFFER_SIZE = 1024;
    using (BinaryReader reader = new BinaryReader(responseStream))
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(localPath, FileMode.Create)))
        {
            int byteRead = 0;
            do
            {
                byte[] buffer = reader.ReadBytes(READ_BUFFER_SIZE);
                byteRead = buffer.Length;
                writer.Write(buffer);
                byteTransfered += byteRead;
            } while (byteRead == READ_BUFFER_SIZE);                        
        }                
    }
