    MyObject obj = new MyObject();
    byte[] bytes;
    IFormatter formatter = new BinaryFormatter();
    using (Stream stream = new MemoryStream())
    {
       formatter.Serialize(stream, obj);
       bytes = stream.ToArray();
    }
