    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace Serialiser
    {
        static class SerialiseInterface
        {
            public static void SerialiseAnimals()
            {
                String finalXml;
    
                // Serialize
                {
                    var animals = new ListOfIAnimal{
                        new Dog(),
                        new Cat()
                    };
    
                    var xmlSerializer = new XmlSerializer(animals.GetType());
                    var stringBuilder = new StringBuilder();
                    var xmlTextWriter = XmlTextWriter.Create(stringBuilder, new XmlWriterSettings { NewLineChars = "\r\n", Indent = true });
                    xmlSerializer.Serialize(xmlTextWriter, animals);
                    finalXml = stringBuilder.ToString();
                }
    
                // Deserialise
                {
                    var xmlSerializer = new XmlSerializer(typeof(ListOfIAnimal));
                    var xmlReader = XmlReader.Create(new StringReader(finalXml));
                    ListOfIAnimal animals = (ListOfIAnimal)xmlSerializer.Deserialize(xmlReader);
                }
            }
        }
    
        public class ListOfIAnimal : List<IAnimal>, IXmlSerializable
        {
            public ListOfIAnimal() : base() { }
    
            #region IXmlSerializable
            public System.Xml.Schema.XmlSchema GetSchema() { return null; }
    
            public void ReadXml(XmlReader reader)
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.Element || reader.Name != "IAnimal") continue;
                    Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
                    XmlSerializer serial = new XmlSerializer(type);
                    reader.Read();
                    this.Add((IAnimal)serial.Deserialize(reader));
                }
            }
    
            public void WriteXml(XmlWriter writer)
            {
                foreach (IAnimal animal in this)
                {
                    writer.WriteStartElement("IAnimal");
                    writer.WriteAttributeString("AssemblyQualifiedName", animal.GetType().AssemblyQualifiedName);
                    XmlSerializer xmlSerializer = new XmlSerializer(animal.GetType());
                    xmlSerializer.Serialize(writer, animal);
                    writer.WriteEndElement();
                }
            }
            #endregion
        }
    
        public interface IAnimal { int Age { get; set; } }
        public class Dog : IAnimal { public int Age { get; set;} public int Teeth { get; set;} }
        public class Cat : IAnimal { public int Age { get; set;} public int Paws { get; set;} }
    }
