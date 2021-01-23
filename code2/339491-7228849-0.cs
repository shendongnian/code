    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var key = doc
                .Descendants("setting")
                .Descendants("key")
                .FirstOrDefault(x => x.Attribute("name").Value == "ankit");
            if (key != null)
            {
                key.Attribute("value").Value = "yes";
            }
            doc.Save("new.xml");
        }
    }
