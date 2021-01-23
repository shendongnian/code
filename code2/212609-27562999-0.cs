    public void ReadXml(XmlReader reader)
    {
        reader.Read();
        do
        {
            if (!XmlNodeType.Element.Equals(reader.NodeType))
            {
                if (!XmlNodeType.EndElement.Equals(reader.NodeType))
                {
                    log.error(reader.NodeType + " is an unknown NodeType for " + this.GetType());
                }
                // return while further reading would move the reader position to another / outer element and will lead to skipped elements in parser
                return;
            }
            switch (reader.Name)
            {
                case "tilecol":
                    col = reader.ReadElementContentAsFloat();
                    break;
                 default:
                    log.error(reader.Name + " is not a valid XMLElement for " + this.GetType());
                    reader.Read();
                    break;
            }
        }
        while (!reader.EOF);
     }
