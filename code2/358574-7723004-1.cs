    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    public class Employee 
    {
        [XmlAttribute] public string Name { get; set; }
        [XmlAttribute] public int Age { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            var me = new Employee {
                Name = "Vyacheslav", Age = 23
            };
            var serializer = new XmlSerializer(typeof (Employee));
            using (var file = File.Create("file.txt"))
            using (var writer = XmlWriter.Create(file, settings))
            {
                serializer.Serialize(writer, me);
            }
        }
    }
