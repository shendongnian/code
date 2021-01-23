    class XElementComparer : IEqualityComparer<XElement>
    {
        public bool Equals(XElement x, XElement y)
        {
            var xTitle = x.Attribute("title");
            var yTitle = y.Attribute("title");
            if (xTitle == null || yTitle == null) return false;
            return xTitle.Value == yTitle.Value;
        }
        public int GetHashCode(XElement obj)
        {
            return base.GetHashCode();
        }
    }
