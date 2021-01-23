    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var johnSmith = doc
                .Descendants("User")
                .Descendants("Name")
                .Where(x => x.Value == "John Smith")
                .Select(x => x.Parent)
                .First();
            johnSmith.Add(
                new XElement("test",
                    new XElement("Date", "30.10.2011"),
                    new XElement("points", "21")
                )
            );
            doc.Save("new.xml");
        }
    }
