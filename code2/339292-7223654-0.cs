    class Program
    {
        static void Main(string[] args)
        {
            XElement main = XElement.Load(@"users.xml");
            // write new data to new file
            string newDate = "01.01.2012";
            string newPoints = "42";
            main.Descendants("User")
                .Descendants("Name")
                .Where(e => e.Value == "John Smith")
                .Select(e => e.Parent)
                .First()
                .Add(new XElement("test",
                    new XElement("date", newDate),
                    new XElement("points", newPoints)
                    )
                );
            main.Save("users2.xml");
        }
    }
