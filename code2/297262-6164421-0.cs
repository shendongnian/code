    public class Unit
    {
        public string Name { get; set; }
        public List<Unit> Children { get; set; }
    }
    class Program
    {
        public static void Main()
        {
            XDocument doc = XDocument.Load("test.xml");
            List<Unit> units = LoadUnits(doc.Descendants("Units").Elements("Unit"));
        }
        public static List<Unit> LoadUnits(IEnumerable<XElement> units)
        {
            return units.Select( x=> new Unit() 
                                     { Name = x.Attribute("Name").Value, 
                                       Children = LoadUnits(x.Elements("Unit")) 
                                     }).ToList();
        }
    }
