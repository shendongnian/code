        private static List<XElement> GetElements(XDocument doc, string elementName)
        {
            List<XElement> elements = new List<XElement>();
            foreach (XNode node in doc.DescendantNodes())
            {
                if (node is XElement)
                {
                    XElement element = (XElement)node;
                    if (element.Name.LocalName.Equals(elementName))
                        elements.Add(element);
                }
            }
            return elements;
        }
