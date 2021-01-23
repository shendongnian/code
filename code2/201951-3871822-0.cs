    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("test.xml",
                                           LoadOptions.PreserveWhitespace);
            doc.Declaration = new XDeclaration("1.0", "utf-8", null);
            StringWriter writer = new Utf8StringWriter();
            doc.Save(writer, SaveOptions.None);
            Console.WriteLine(writer);
        }
        
        private class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }
    }
