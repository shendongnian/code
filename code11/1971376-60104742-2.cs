    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    
    // Runtime Target = .NET Core v2.1
    namespace XmlSerialize
    {
        class Program
        {
            static void Main(string[] args)
            {
                var mickey = new Employee { FirstName = "Mickey", LastName = "Mouse" };
                var asterix = new Employee { FirstName = "Asterix", LastName = "" };
                var obelix = new Employee { FirstName = "Obelix", LastName = null };
                var nixnix = new Employee { FirstName = null, LastName = null };
    
                Console.WriteLine(SerializeXml(mickey) + SerializeXml(asterix) + SerializeXml(obelix) + SerializeXml(nixnix));
            }
    
            public static string SerializeXml<T>(T instanceToSerialize)
            {
                var serializer = new XmlSerializer(instanceToSerialize.GetType(), string.Empty);
                var result = string.Empty;
                using (var stringWriter = new StringWriter())
                {
                    serializer.Serialize(stringWriter, instanceToSerialize);
                    result = stringWriter.ToString().ToString();
                }
                return result;
            }
        }
    
        [XmlRoot("Employee")]
        public sealed class Employee
        {
            [XmlAttribute("FirstName")]
            public string FirstName { get; set; }
    
            [XmlIgnore]
            public string LastName { get; set; }
    
            [XmlAttribute("LastName")]
            public string SerializableLastName // <------------ Might this help?
            {
                get { return this.LastName ?? string.Empty; }
                set { this.LastName = value; }
            }
    
            [XmlElement]
            public List<string> Skills { get; set; }
        }
    }
