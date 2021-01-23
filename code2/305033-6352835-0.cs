    using System.Runtime.Serialization.Formatters.Binary;
    using System.IO;
    public List<TKey> Generate<TKey>()
    {
        byte[] theData = MyWebService.GetData1();
        List<Object> theList = (List<Object>)new BinaryFormatter().Deserialize(new MemoryStream(theData));
        return theList.ConvertAll(i => (TKey) i);
    }
