    private static void Save(T yourobject, Type[] extraTypesInyourObject, string path)
    {
        using (TextWriter textWriter = new TextWriter(path))
        {
            XmlSerializer xmlSerializer = CreateXmlSerializer(extraTypes);
            xmlSerializer.Serialize(textWriter, yourobject);
        }
    }
        private static XmlSerializer CreateXmlSerializer(Type[] extraTypes)
        {
            Type ObjectType = typeof(T);
            XmlSerializer xmlSerializer = null;
            if (extraTypes!=null)
            {
                xmlSerializer = new XmlSerializer(ObjectType, extraTypes);
            }
            else
            {
                xmlSerializer = new XmlSerializer(ObjectType);
            }
            return xmlSerializer;
        }
