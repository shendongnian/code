private bool ValidateXml(string xmlFilePath, string schemaFilePath, string schemaNamespace, Type rootType)
{
    XmlSerializer serializer = new XmlSerializer(rootType);
    using (var fs = new StreamReader(xmlFilePath, Encoding.GetEncoding("iso-8859-1")))
    {
        object deserializedObject;
        var xmlReaderSettings = new XmlReaderSettings();
        if (File.Exists(schemaFilePath))
        {
            //select schema for validation	
            xmlReaderSettings.Schemas.Add(schemaNamespace, schemaPath);	
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            try
            {
            using (var xmlReader = XmlReader.Create(fs, xmlReaderSettings))
            {                
                if (serializer.CanDeserialize(xmlReader))
                {
                    return true;
                    //deserializedObject = serializer.Deserialize(xmlReader);
                }
                else
                {
                    return false;
                }
            }
            }
            catch(Exception ex)
            { return false; }
        }
    }
}
