    int binaryStart = 100;
    int binaryEnd = 150;
    var buffer = new byte[binaryEnd - binaryStart];
    string base64String = null;
    using (System.IO.Stream fileStream = new FileStream(@"your file path", FileMode.Open | FileMode.Append))
    {
        using (System.IO.BinaryReader reader = new BinaryReader(fileStream))
        {
            reader.Read(buffer, 0, buffer.Length);
           
            base64String = Convert.ToBase64String(buffer);
        }
        //the following code is not tested but it should be fine "write a comment if you find any issue"
        using (System.IO.BinaryWriter writer = new BinaryWriter(fileStream))
        {
            writer.Seek(binaryStart, SeekOrigin.Begin);
            writer.Write(base64String);
         }
    }
    
