    public static object DeSerialize<T>(string data)
        {
           StringReader rdr = new StringReader(data);
           XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
           var result = (T)xmlSerializer.Deserialize(rdr);
           return result; 
        }
    var fl = (List<InputData>)Serializer.DeSerialize<List<InputData>>(serializedData);
