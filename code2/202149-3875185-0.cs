        var parts = new List<Part>() { ...... parts here ...... };        
        using (XmlWriter writer = XmlWriter.Create("f:\\MyParts.xml", settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("MyParts");
            foreach(var part in parts)
            {
                writer.WriteStartElement("parts");
                writer.WriteStartElement("item");
                writer.WriteString(part.Item);
                writer.WriteEndElement(); // </item>
                writer.WriteStartElement("color");
                writer.WriteString(part.Color);
                writer.WriteEndElement();
                writer.WriteStartElement("size");
                writer.WriteString(part.Size);
                writer.WriteEndElement(); // </size>
                writer.WriteEndElement(); // </parts>
            }
            writer.WriteEndElement(); // </MyParts>
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }
The general idea is that, for each part in your list of parts, you write the "parts" <parts> (should be "part"?) tag and all of its contents, filling item, color and size with data from a Part class, which in its simplest form might be:
    class Part
    {
        public string Item { get; set; }
        public Color Color { get; set; }
        public string Size { get; set; }
    }
