    private static string SerializeToString(object objectToSerialize)
    {
      var serializer = new DataContractSerializer(objectToSerialize.GetType());
      var output = new StringBuilder();
      var xmlWriter = XmlWriter.Create(output);
    
      serializer.WriteObject(xmlWriter, objectToSerialize);
      xmlWriter.Close();
                
      return output.ToString();
    }
