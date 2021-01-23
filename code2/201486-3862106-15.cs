    using System;
    using System.Text;
    using System.IO;
    using System.Xml.Serialization;
    
    public class Test
    {    
        public int X { get; set; }
        
        static void Main()
        {
            Test t = new Test();
            var serializer = new XmlSerializer(typeof(Test));
            string utf8;
            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, t);
                utf8 = writer.ToString();
            }
            Console.WriteLine(utf8);
        }
        
        
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
