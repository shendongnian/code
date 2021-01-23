private void ValidateXml(string xmlFilePath, string schemaFilePath, Type rootType)
{
    XmlSerializer serializer = new XmlSerializer(rootType);
    using (var fs = new StreamReader(xmlFilePath, Encoding.GetEncoding("iso-8859-1")))
    {
        object deserializedObject;
        var xmlReaderSettings = new XmlReaderSettings();
        if (File.Exists(schemaFilePath))
        {
            //select schema for validation		
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            using (var xmlReader = XmlReader.Create(fs, xmlReaderSettings))
            {
                if (serializer.CanDeserialize(xmlReader))
                {
                    deserializedObject = serializer.Deserialize(xmlReader);
                }
                else
                {
                    Console.WriteLine("Cannot deserialize xml");
                }
            }
        }
    }
}
