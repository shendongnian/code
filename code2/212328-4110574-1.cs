    public object Clone() {
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream stream = new MemoryStream();
        formatter.Serialize(stream, this);
        stream.Seek(0, SeekOrigin.Begin);
        return (MyForm) formatter.Deserialize(stream);
    }
