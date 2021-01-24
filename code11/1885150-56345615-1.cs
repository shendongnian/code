    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.IO;
    using System.Xml;
   
    static void Main(string[] args)
    {
        var document = new XDocument();
        // use path to your xml file
        using (FileStream fs = File.OpenRead("examp.xml"))
        {
            using (XmlTextReader reader = new XmlTextReader(fs))
            {
                document = XDocument.Load(reader);
            }
        }
        int value;
        var query = (from element in document.Element("Base").Elements("Team")
                     where int.TryParse(element.Element("TeamId").Value.ToString(), out value)
                     select new
                     {
                         TeamName = element.Element("TeamName").Value,
                         TeamId = element.Element("TeamId").Value
                     }).ToList();
        // do further processing with filtered data
        foreach (var item in query)
        {
            Console.WriteLine($"{item.TeamName}: {item.TeamId}");
        }
        Console.ReadKey();
    }
