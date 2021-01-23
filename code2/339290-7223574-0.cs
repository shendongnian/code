    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var johnSmith = doc
                .Element("Users")
                .Elements("User")
                .Where(x => x.Element("Name").Value == "John Smith")
                .First();
            johnSmith.Add(
                new XElement("test",
                    new XElement("Date", "new date"),
                    new XElement("points", "new points")
                )
            );
            doc.Save("new.xml");
        }
    }
