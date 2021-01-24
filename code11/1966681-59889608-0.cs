                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
2) Xml serializer with array creates two tags 1) Persons 2) Person.  See the output of code below to see these elements.
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Person p1 = new Person() { A = 1, B = 2};
                Person p2 = new Person() { A = 45, B = 65 };
                Person p3 = new Person() { A = 213, B = 34 };
                Person p4 = new Person() { A = 45, B = 234 };
                Person p5 = new Person() { A = 324, B = 123 };
                Person p6 = new Person() { A = 53, B = 53 };
                Person p7 = new Person() { A = 46545, B = 6435 };
                Person p8 = new Person() { A = 4355, B = 6435 };
                Person p9 = new Person() { A = 4455, B = 6455 };
                Person p10 = new Person() { A = 4455, B = 6345 };
                List<Person> people = new List<Person>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
                WriteToXmlFile(FILENAME, people);
            }
            public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
            {
                TextWriter writer = null;
                try
                {
                    var serializer = new XmlSerializer(typeof(T));
                    writer = new StreamWriter(filePath, append);
                    serializer.Serialize(writer, objectToWrite);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }
            public static T ReadFromXmlFile<T>(string filePath) where T : new()
            {
                TextReader reader = null;
                try
                {
                    var serializer = new XmlSerializer(typeof(T));
                    reader = new StreamReader(filePath);
                    Console.WriteLine("file readed correctly");
                    return (T)serializer.Deserialize(reader);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }
            }
        }
        public class Person
        {
            public int A { get; set; }
            public int B { get; set; }
        }
    }
