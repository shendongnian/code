    internal string Serialize(Object documentSettings)
    {
       StringBuilder serialXML = new StringBuilder();
       DataContractSerializer dcSerializer = new DataContractSerializer(obj.GetType());
       using (XmlWriter xWriter = XmlWriter.Create(serialXML))
       {
           dcSerializer.WriteObject(xWriter, obj);
           xWriter.Flush();
           return serialXML.ToString();
       }
    }
