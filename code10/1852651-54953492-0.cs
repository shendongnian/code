        public static void ReadXmlFile()
        {
            XDocument doc = XDocument.Load(@"xmlfiledados.xml");
            XElement element = doc.Element("airlines").Descendants("airline").Where(a => a.Element("name").Value.Equals("HK Express")).First();
            Console.WriteLine(element.Element("name").Value);
            Console.WriteLine(element.Element("origin").Value);
            Console.WriteLine(element.Element("destination").Value);
            Console.WriteLine(element.Element("date").Value);
        }
