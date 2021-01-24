    public class XMLReader
    {
            public XMLReader()
            {
            }
            public  List<airlines> leerXML() 
            {            
            Console.WriteLine("Enter the airline you wish to search: ");
                string name;
                name= Console.ReadLine().ToUpper();
                if (nombre == "V"){
                XElement info = XElement.Load(@"C:\Users\thoma\Documents\Visual Studio 2019\Backup Files\data.xml");
                IEnumerable<XElement> airlines =
                    from el in info.Elements("airline")
                    where (string)el.Element("name") == "HK"
                    select el;
                foreach (XElement el in airlines)
                    Console.WriteLine((string)el.Attribute("origin"));
              }            
                return null;
              }
      }
