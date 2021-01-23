     public static object Deserialize(string xml, Type toType)
        {
            
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                System.IO.StreamReader str = new System.IO.StreamReader(memoryStream);
                System.Xml.Serialization.XmlSerializer xSerializer = new System.Xml.Serialization.XmlSerializer(toType);
                return xSerializer.Deserialize(str);
            }
        }
