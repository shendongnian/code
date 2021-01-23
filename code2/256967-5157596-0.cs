    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("test.xml");
            var groupedGroups = doc.Descendants("group")
                       .GroupBy(x => x.Parent);
            
            foreach (var groupedGroup in groupedGroups)
            {
                // Create the new element (copies each <group>)
                groupedGroup.Key.Add(new XElement("groups", groupedGroup));
                // Remove all the old ones
                foreach (var element in groupedGroup)
                {
                    element.Remove();
                }
            }
            Console.WriteLine(doc);
        }
    }
