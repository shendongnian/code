    class Program
    {
        static void Main(string[] args)
        {
            string xml = "<foo><property name=\"John\" value=\"Doe\" id=\"1\"/><property name=\"Paul\" value=\"Lee\" id=\"1\"/><property name=\"Ken\" value=\"Flow\" id=\"1\"/><property name=\"Jane\" value=\"Horace\" id=\"1\"/><property name=\"Paul\" value=\"Lee\" id=\"1\"/></foo>";
            XElement x = XElement.Parse(xml);
            var a = x.Elements().Distinct(new MyComparer()).ToList();
        }
    }
    class MyComparer : IEqualityComparer<XElement>
    {
        public bool Equals(XElement x, XElement y)
        {
            return x.Attribute("name").Value == y.Attribute("name").Value;
        }
        public int GetHashCode(XElement obj)
        {
            return obj.Attribute("name").Value.GetHashCode();
        }
    }
