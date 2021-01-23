    class Program
    {
        static void Main(string[] args)
        {
            var x = new XElement("root", new XElement("t", new XAttribute("xmlns", "")), new XAttribute("aaab", "bb"));
            Console.WriteLine(x);
            RemoveEmptyNamespace(x);
            Console.WriteLine(x);
        }
    
        private static void RemoveEmptyNamespace(XElement element)
        {
            XAttribute attr = element.Attribute("xmlns");
            if (attr != null && string.IsNullOrEmpty(attr.Value))
                attr.Remove();
            foreach (XElement el in element.Elements())
                RemoveEmptyNamespace(el);
        }
    }
