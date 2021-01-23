    public static TDataSet LoadBinary<TDataSet>(Stream stream) where TDataSet : DataSet
    {
        var formatter = new BinaryFormatter();
        return (TDataSet)formatter.Deserialize(stream);
    }
    public static void WriteBinary<TDataSet>(this TDataSet dataSet, Stream stream) where TDataSet : DataSet
    {
        dataSet.RemotingFormat = SerializationFormat.Binary;
        var formatter = new BinaryFormatter();
        formatter.Serialize(stream, dataSet);
    }
