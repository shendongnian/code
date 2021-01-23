    MyObject obj = new MyObject();
    byte[] bytes;
    IFormatter formatter = new BinaryFormatter();
    using (MemoryStream stream = new MemoryStream())
    {
       formatter.Serialize(stream, obj);
       bytes = stream.ToArray();
    }
