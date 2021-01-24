    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication137
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(INPUT_FILENAME);
                XmlWriter writer = XmlWriter.Create(OUTPUT_FILENAME);
                doc.WriteTo(writer);
                writer.Flush();
                writer.Close();
            }
        }
    }
