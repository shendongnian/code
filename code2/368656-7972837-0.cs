    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    [XmlType("Field")]
    public class SearchField
    {
        [XmlAttribute("alias")]
        public string Alias;
    
        [XmlAttribute("entity")]
        public string Entity;
    }
    
    class Program
    {
        static void Main()
        {
            using (var reader = new StringReader("<Field entity=\"en\" />"))
            {
                var serializer = new XmlSerializer(typeof(SearchField));
                var s = (SearchField)serializer.Deserialize(reader);
                Console.WriteLine(s.Alias);
                Console.WriteLine(s.Entity);
            }
        }
    }
