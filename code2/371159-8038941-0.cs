    public void SerializeObject(NetworkStream stream, ObjectToSerialize objectToSerialize)
    {
       varbFormatter = new BinaryFormatter();
       bFormatter.Serialize(stream, objectToSerialize);
       stream.Close();
    }
 
    public ObjectToSerialize DeSerializeObject(NetworkStream stream)
    {
       ObjectToSerialize objectToSerialize;
       var bFormatter = new BinaryFormatter();
       objectToSerialize = (ObjectToSerialize)bFormatter.Deserialize(stream);
       stream.Close();
       return objectToSerialize;
    }
