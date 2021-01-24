    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication106
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XSerBase test = new XSerBase()
                {
                    XSerTest = new List<XSerTest>() { 
                        new XSerTest() { TestValue = "123"},
                        new XSerTest() { TestValue = "456"}
                    }
                };
                
                XmlSerializer serializer = new XmlSerializer(typeof(XSerBase));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME,settings);
                serializer.Serialize(writer, test);
                writer.Flush();
                writer.Close();
     
            }
     
        }
        public class XSerBase
        {
            [XmlElement("XSerTest")]
            public List<XSerTest> XSerTest { get; set; }
        }
        public class XSerTest
        {
            public string TestValue { get; set; } 
        }
    }
