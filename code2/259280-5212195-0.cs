    public object Deserialize(XmlReader xmlReader, string encodingStyle, XmlDeserializationEvents events)
    {
        …
        try
        {
            if (this.primitiveType != null)
            {
                …
                return this.DeserializePrimitive(xmlReader, events);
            }
            if ((this.tempAssembly == null) || this.typedSerializer)
            {
                XmlSerializationReader reader = …
                try
                {
                    return this.Deserialize(reader);
    …
           
