    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication29
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "visits")
                    {
                        reader.ReadToFollowing("visits");
                    }
                    if (!reader.EOF)
                    {
                        XElement visits = (XElement)XElement.ReadFrom(reader);
                        XElement filedata = visits.Element("filedata");
                        filedata.SetValue("New Data");
                    }
                }
            }
        }
    }
