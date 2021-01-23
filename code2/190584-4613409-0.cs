    public MyContract Deserialize(string file)
    {
      try
      {
        using (var stream = loadFile())
        {
          return loadWithDataContractSerializer(stream);
        }
      }
      catch (SerializationException)
      {
        using (var stream = openForRead(file))
        {
          return convertToContract(loadWithSoapFormatter(stream));
        }
      }
    }
    private MyContract loadWithDataContractSerializer(Stream s);
    private MyOldObject loadWithSoapFormatter(Stream s);
    private MyContract convertToContract(MyOldObject obj);
    
    public void Serialize(string file, MyContract data)
    {
      using (var stream = openForWrite(file))
      {
        writeWithDataContractSerializer(stream, data);
      }
    }
