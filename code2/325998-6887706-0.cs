    static public void SerializeToXML<_type>(_type item,string fileName)
    {
      XmlSerializer serializer = new XmlSerializer( item.GetType() );
      TextWriter textWriter = new StreamWriter( fileName );
      serializer.Serialize(textWriter, item);
      textWriter.Close();
    }
    static _type DeserializeFromXML<_type>(string fileName)
    {
       XmlSerializer deserializer = new XmlSerializer(typeof(_type));
       TextReader textReader = new StreamReader( fileName );
    
       _type item = (_type)deserializer.Deserialize(textReader);
       textReader.Close();
    
       return item;
    }
