    public %object% DeserializeGSFiles(string content)
        {
            Type type = typeof(%object%);
            XmlSerializer xmlSerializer;
            byte[] byteArray = Encoding.UTF8.GetBytes(content);
            MemoryStream stream = new MemoryStream(byteArray);
            try
            {
                xmlSerializer = new XmlSerializer(type);
                %object% objectFromXml = (%object%)xmlSerializer.Deserialize(stream);
                return objectFromXml;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
