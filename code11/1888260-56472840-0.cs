        using (TextReader reader = new StringReader(inputString))
        using (XmlReader xmlReader = XmlReader.Create(reader))
        {
            if (serializer.CanDeserialize(xmlReader))
            {
                result = (T)serializer.Deserialize(xmlReader);
            }
        }
