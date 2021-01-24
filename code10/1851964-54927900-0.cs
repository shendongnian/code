    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication103
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                MyClass myClass = new MyClass();
                myClass.Serialize(FILENAME);
     
            }
        }
        public class MyClass
        {
             public string test { get; set; }
             public void Serialize(string filename)
             {
                 SerializePresets(filename);
             }
             private void SerializePresets(string path)
             {
                 XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyClass));
                 using (TextWriter writer = new StreamWriter(path))
                 {
                     xmlSerializer.Serialize(writer, this);
                 }
            }
        }
    }
