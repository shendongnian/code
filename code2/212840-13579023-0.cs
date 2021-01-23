    public static bool Serialize<T>(T value, ref string serializeXml)
        {
            if (value == null)
            {
                return false;
            }
            try
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(T));
                StringWriter stringWriter = new StringWriter();
                XmlWriter writer = XmlWriter.Create(stringWriter);
                xmlserializer.Serialize(writer, value);
                serializeXml = stringWriter.ToString(); 
                writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
