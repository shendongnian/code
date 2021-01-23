        private int GetTotalFromXml(string xml)
        {
            XmlReader reader = XmlReader.Create(new StringReader(xml));
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("web:Total"))
                    {
                        return reader.ReadElementContentAsInt();
                    }
                }
            }
            return 0;
        }
