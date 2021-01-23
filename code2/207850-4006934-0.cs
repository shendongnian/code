    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            string xml = @"... your xml ";
            doc.LoadXml(xml);
            // Using SelectNodes with Xpath
            XmlNodeList list = doc.SelectNodes("WinDLN/Program[@ID='2']");
            Console.WriteLine(list.Count); // prints 1
            list = doc.SelectNodes("WinDLN/Program[@ID]");
            Console.WriteLine(list.Count); // prints 3 (selected all IDs)
        }
    }
