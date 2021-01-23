            if (xml.Element(parent) != null)
            {
                var myNode = xml.Element(parent).Element(node);
                if (node != null)
                    myNode.Value = newVal;
            }
            else
            {
                xml.Element(parent).Add(new XElement(node, newVal));
            }
