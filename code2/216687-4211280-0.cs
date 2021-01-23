    using System.Xml;
    using System.Xml.Serialization;
    public class Foo
    {
        public string Bar { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            using (XmlWriter writer = XmlWriter.Create("my.xml", settings))
            {
                XmlSerializer ser = new XmlSerializer(typeof(Foo));
                Foo foo = new Foo();
                foo.Bar = "abc";
                ser.Serialize(writer, foo);
            }
    
        }
    }
