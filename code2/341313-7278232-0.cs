    MemoryStream output = new MemoryStream();
    try
    {
       using (MemoryStream ms = new MemoryStream(cbytes))
       using (DeflateStream ds = new DeflateStream(ms, CompressionMode.Decompress, true)) {
    
        int num;
        byte[] buffer = new byte[100];
        while ((num = ds.Read(buffer, 0, buffer.Length)) != 0)
        {
            output.Write(buffer, 0, num);
        }
       }
       MyObAfterSerDeser = (MyClass)bf.Deserialize(output);
    }
    finally
    {
        output.Dispose();
    }
