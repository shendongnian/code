    protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey)
    {
        int count = reader.AttributeCount;
        //First get the attributes
        string attrName;
        for (int i = 0; i < count; i++)
        {
            reader.MoveToAttribute(i);
            attrName = reader.Name;
            this[attrName] = reader.Value;
        }
        //then get the text content
        reader.MoveToElement();
        text = reader.ReadElementContentAsString();
    }
