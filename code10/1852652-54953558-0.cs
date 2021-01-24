        public void leerXML()
        {
            Console.WriteLine("Enter the airline you wish to search: ");
            string name;
            name = Console.ReadLine().ToUpper();
            if (!String.IsNullOrEmpty(name))
            {
                XElement info = XElement.Load(@"C:\Users\thoma\Documents\Visual Studio 2019\Backup Files\data.xml");
                var airlines = info.XPathSelectElements("airline");
                foreach (XElement el in airlines)
                {
                    if (!String.IsNullOrEmpty(el.Element("name").Value) && ((string)el.Element("name").Value).IndexOf(name) >= 0) 
                    {
                        Console.WriteLine((string) el.Element("origin").Value);
                    }
                }
            }
        }
     static void Main(string[] args)
        {
            XMLReader xmlReader = new XMLReader()
            xmlReader.leerXML(); 
            Console.ReadLine();
        }  
