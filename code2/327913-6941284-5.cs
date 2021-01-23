        public static void Main()
        {
            var xmldoc = XDocument.Load(@"TextFile1.xml");
            XNamespace p = "http://www.w3.org/1999/xhtml";
            var result = from item in xmldoc.Descendants(p + "a")
                         select item;
            foreach (var item in result.ToList())
            {
                string href = item.Attribute("href").Value;
            }
        }
    }
