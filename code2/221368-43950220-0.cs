    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace XmlCustomSerializer
    {
        public class Person : IXmlSerializable
        {
            public string Name1;
    
            public string Name2;
    
            [XmlIgnore]
            public string Name3;
    
            public Person()
            {
            }
    
            public Person(string first, string second, string third)
            {
                Name1 = first;
                Name2 = second;
                Name3 = third;
            }
    
            public XmlSchema GetSchema()
            {
                return null;
            }
    
            public void ReadXml(XmlReader reader)
            {
                // ....
            }
    
            private static FieldInfo[] _cachedFields = null;
            public void WriteXml(XmlWriter writer)
            {
                var customWriter = writer as XmlCustomWriter;
                if (customWriter == null)
                    throw new ArgumentException("writer");
    
                if (_cachedFields == null)
                {
                    _cachedFields = typeof(Person).GetFields();
                }
    
                foreach (FieldInfo finf in customWriter.FieldsToSerialize)
                {
                    if (_cachedFields.Contains(finf))
                    {
                        writer.WriteElementString(finf.Name, (string)finf.GetValue(this));
                    }
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var person = new Person
                {
                    Name1 = "Some",
                    Name2 = "Person",
                    Name3 = "Name"
                };
    
                var settings = new XmlWriterSettings { Indent = true, Encoding = Encoding.ASCII };
                var allFields = typeof(Person).GetFields();
    
                XmlSerializer xSer = new XmlSerializer(typeof(Person));
                
                using (var stream = new MemoryStream())
                {
                    var xmlCustomWriter = new XmlCustomWriter(
                        XmlWriter.Create(new StreamWriter(stream), settings));
                    
                    //serialize all fields
                    xmlCustomWriter.FieldsToSerialize = allFields;
    
                    xSer.Serialize(xmlCustomWriter, person);
    
                    stream.Seek(0, SeekOrigin.Begin);
                    Console.WriteLine(new StreamReader(stream).ReadToEnd());
                }
    
                using (var stream = new MemoryStream())
                {
                    var xmlCustomWriter = new XmlCustomWriter(
                        XmlWriter.Create(new StreamWriter(stream), settings));
    
                    //serialize 2 fields
                    xmlCustomWriter.FieldsToSerialize = allFields.Skip(1);
    
                    xSer.Serialize(xmlCustomWriter, person);
    
                    stream.Seek(0, SeekOrigin.Begin);
                    Console.WriteLine(new StreamReader(stream).ReadToEnd());
                }
    
                Console.Read();
            }
        }
    }
