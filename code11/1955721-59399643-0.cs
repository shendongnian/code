        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("settings.xml");
            string connectionStrings = xmlDoc.GetElementsByTagName("connectionStrings")[0].InnerXml;
            string tag = "connectionString=\"";
            string connectionString = connectionStrings.Substring(connectionStrings.IndexOf(tag) + tag.Length);
            string[] tokens = connectionString.Split(';');
            Console.WriteLine(tokens.FirstOrDefault(t => t.Contains("data source=")));
            Console.WriteLine(tokens.FirstOrDefault(t => t.Contains("User Id=")));
            Console.WriteLine(tokens.FirstOrDefault(t => t.Contains("Password=")));
        }
