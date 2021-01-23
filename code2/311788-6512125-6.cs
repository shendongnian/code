    int binaryStart = 100;
    int binaryEnd = 150;
    //buffer to copy the remaining data to it and insert it after inserting the base64string
    byte[] dataTailBuffer = null;
    string base64String = null;
    //get the binary data and convert it to base64string
    using (System.IO.Stream fileStream = new FileStream(@"c:\Test Soap", FileMode.Open, FileAccess.Read))
    {
        using (System.IO.BinaryReader reader = new BinaryReader(fileStream))
        {
            reader.BaseStream.Seek(binaryStart, SeekOrigin.Begin);
            var buffer = new byte[binaryEnd - binaryStart];
            reader.Read(buffer, 0, buffer.Length);
            base64String = Convert.ToBase64String(buffer);
            if (reader.BaseStream.Position < reader.BaseStream.Length - 1)
            {
                dataTailBuffer = new byte[reader.BaseStream.Length - reader.BaseStream.Position];
                reader.Read(dataTailBuffer, 0, dataTailBuffer.Length);
            }
        }
    }
    //write the new base64string at specifid location.
    using (System.IO.Stream fileStream = new FileStream(@"C:\test soap", FileMode.Open, FileAccess.Write))
    {
        using (System.IO.BinaryWriter writer = new BinaryWriter(fileStream))
        {
            writer.Seek(binaryStart, SeekOrigin.Begin);
            writer.Write(base64String);//writer.Write(Convert.FromBase64String(base64String));
            if (dataTailBuffer != null)
            {
                writer.Write(dataTailBuffer, 0, dataTailBuffer.Length);
            }
        }
    }
