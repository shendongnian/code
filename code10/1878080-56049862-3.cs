    public static class JsonExtensions
    {
        public static void StreamNested(Stream from, Stream to, string [] path)
        {
            var reversed = path.Reverse().ToArray();
            using (var xr = JsonReaderWriterFactory.CreateJsonReader(from, XmlDictionaryReaderQuotas.Max))
            {
                foreach (var subReader in xr.ReadSubtrees(s => s.Select(n => n.LocalName).SequenceEqual(reversed)))
                {
                    using (var xw = JsonReaderWriterFactory.CreateJsonWriter(to, Encoding.UTF8, false))
                    {
                        subReader.MoveToContent();
                        xw.WriteStartElement("root");
                        xw.WriteAttributes(subReader, true);
                        subReader.Read();
                        while (!subReader.EOF)
                        {
                            if (subReader.NodeType == XmlNodeType.Element && subReader.Depth == 1)
                                xw.WriteNode(subReader, true);
                            else
                                subReader.Read();
                        }
                        xw.WriteEndElement();
                    }
                }
            }
        }
    }
    public static class XmlReaderExtensions
    {
        public static IEnumerable<XmlReader> ReadSubtrees(this XmlReader xmlReader, Predicate<Stack<XName>> filter)
        {
            Stack<XName> names = new Stack<XName>();
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    names.Push(XName.Get(xmlReader.LocalName, xmlReader.NamespaceURI));
                    if (filter(names))
                    {
                        using (var subReader = xmlReader.ReadSubtree())
                        {
                            yield return subReader;
                        }
                    }
                }
                if ((xmlReader.NodeType == XmlNodeType.Element && xmlReader.IsEmptyElement)
                    || xmlReader.NodeType == XmlNodeType.EndElement)
                {
                    names.Pop();
                }
            }
        }
    }
