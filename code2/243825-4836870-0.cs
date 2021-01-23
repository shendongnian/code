    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    public class MyClass
    {
        [XmlElement("test")]
        public string Test { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            XmlSerializer ser = new XmlSerializer(typeof(MyClass));
            MyClass orig = new MyClass { Test = " " }, clone;
            using (var file = XmlWriter.Create("my.xml"))
            {
                ser.Serialize(file, orig);
            }
            using (var file = XmlReader.Create("my.xml"))
            {
                clone = (MyClass)ser.Deserialize(file);
            }
            Console.WriteLine("'" + clone.Test + "'");
            Console.WriteLine(File.ReadAllText("my.xml"));
        }
    }
