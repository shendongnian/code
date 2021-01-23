    public static void SerializeObject<T>(this T toSerialize, String filename)
    {
        TextWriter textWriter;
        try
        {
             XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
             textWriter = new StreamWriter(filename);
    
              xmlSerializer.Serialize(textWriter, toSerialize);
        }
        finally
       {
           textWriter.Close();
       }
