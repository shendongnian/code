        XElement textsElement = ...;
        var newTextsElement = new XElement("texts", texts.Elements().Distinct(new TextElementEqualityComparer()));
        private class TextElementEqualityComparer : IEqualityComparer<XElement>
        {
            public bool Equals(XElement x, XElement y)
            {
                return x.Attribute("top").Value == y.Attribute("top").Value
                    && x.Attribute("left").Value == y.Attribute("left").Value;
            }
            public int GetHashCode(XElement obj)
            {
                return obj.Attribute("top").Value.GetHashCode() ^ obj.Attribute("left").Value.GetHashCode();
            }
        }
