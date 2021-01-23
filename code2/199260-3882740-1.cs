    Public Class Utilities
    {
        public static XmlElement Serialize(object transformObject)
                {
                    XmlElement serializedElement = null;
                    try
                    {
                        MemoryStream memStream = new MemoryStream();
                        XmlSerializer serializer = new XmlSerializer(transformObject.GetType());
                        serializer.Serialize(memStream, transformObject);
                        memStream.Position = 0;
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(memStream);
                        serializedElement = xmlDoc.DocumentElement;
                    }
                    catch (Exception SerializeException)
                    {
        
                    }
                    return serializedElement;
                }
