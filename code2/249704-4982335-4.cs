    public static void ReadData(XmlReader reader)
    {
        reader.ReadStartElement("root");
        reader.ReadToFollowing("NonEmptyElement");
        Console.WriteLine(reader.GetAttribute("Name"));
        reader.ReadStartElement("NonEmptyElement");
        Console.WriteLine(reader.GetAttribute("Name"));
        while (reader.ReadToNextSibling("SubEmptyElement"))
        {
            // ...
        }
        reader.ReadEndElement(/* NonEmptyElement */);
        reader.ReadEndElement(/* root */);
        // ...
    }
