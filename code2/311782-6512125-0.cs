    int binaryStart = 0;
    int binaryEnd = 0;
    var buffer = new byte[binaryEnd - binaryStart];
    using (System.IO.Stream fileStream = new FileStream(@"your file path", FileMode.Open))
    {
        using (System.IO.BinaryReader reader = new BinaryReader(fileStream))
        {
            //reader.BaseStream.Seek(binaryStart, SeekOrigin.Begin);
            reader.Read(buffer, 0, buffer.Length);
        }
    }
    //use your buffer here
