    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;
    
    public class MyClass
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            var table = new Hashtable
            {
                { "obj1", new MyClass { Foo = "foo", Bar = "bar" } },
                { "obj2", new MyClass { Foo = "baz" } },
            };
    
            var sb = new StringBuilder();
            var serializer = new DataContractSerializer(typeof(Hashtable), new[] { typeof(MyClass) });
            using (var writer = new StringWriter(sb))
            using (var xmlWriter = XmlWriter.Create(writer))
            {
                serializer.WriteObject(xmlWriter, table);
            }
    
            Console.WriteLine(sb);
    
            using (var reader = new StringReader(sb.ToString()))
            using (var xmlReader = XmlReader.Create(reader))
            {
                table = (Hashtable)serializer.ReadObject(xmlReader);
            }
        }
    }
