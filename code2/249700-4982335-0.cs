    public static void ReadData(XmlReader reader)
    {
        // Move to root element
        reader.ReadStartElement("root");
        // Move to the empty element
        reader.ReadStartElement("EmptyElement");
        reader.ReadStartElement("NonEmptyElement");
        // Read any children);
        while (reader.ReadToNextSibling("SubEmptyElement"))
        {
            // ...
        }
        // Read the end of the empty element
        reader.ReadEndElement(/* NonEmptyElement */);
        reader.ReadEndElement(/* root */);
        // ...
    }
