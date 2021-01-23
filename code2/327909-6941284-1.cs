    public static class MyClass
        {
    
            public static void Main()
            {
    
    
                var xmldoc = XDocument.Load(@"TextFile1.xml");
                var result = from item in xmldoc.Descendants("a")
                             select item;
    
                foreach (var item in result.ToList())
                {
                    string href = item.Attribute("href").Value;
                }
            }
        }
