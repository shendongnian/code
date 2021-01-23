    Byte[] bytes;
    using (System.IO.BinaryReader r = new System.IO.BinaryReader(request.InputStream))
    {
        // Read the data from the stream into the byte array
        bytes = r.ReadBytes(Convert.ToInt32(request.InputStream.Length));
    }
    MemoryStream mstream = new MemoryStream(bytes);
