    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    [XmlRoot("hibernate-mapping", Namespace = "urn:nhibernate-mapping-2.2")]
    public class HibernateMapping
    {
        [XmlAttribute("assembly")]
        public string AssemblyName { get; set; }
    
        [XmlElement("class")] // should this be a list?
        public Class Class { get; set; }
    }
    
    public class Class
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlAttribute("table")]
        public string Table { get; set; }
    
        private readonly List<Property> properties = new List<Property>();
        [XmlElement("property")]
        public List<Property> Properties { get { return properties; } }
    }
    public class Property
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            File.WriteAllText("my.xml",
                              @"<?xml version=""1.0"" encoding=""utf-8"" ?>
    <hibernate-mapping xmlns=""urn:nhibernate-mapping-2.2"">
        <class name=""Example.Library.Resources.TestObject, Example.Library"" table=""test_object"" lazy=""false"">
            <id name=""TestId"" column=""TestId"" type=""Guid""> 
                <generator class=""assigned"" /> 
            </id> 
            <property name=""Name"" type=""String"" length=""45"" />
        </class>
    </hibernate-mapping>");
    
    
            var ser = new XmlSerializer(typeof(HibernateMapping));
            var obj = (HibernateMapping)ser.Deserialize(new StreamReader("my.xml"));
            Console.WriteLine(obj.Class.Name);
            Console.WriteLine(obj.Class.Table);
            foreach (var prop in obj.Class.Properties)
            {
                Console.WriteLine("prop: " + prop.Name);
            }
            Console.ReadKey();
        }
    }
