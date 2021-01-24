    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication3
    {
        class Program1
        {
            const string BAD_FILENAME = @"c:\temp\test.xml";
            const string Fixed_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(BAD_FILENAME);
                StreamWriter writer = new StreamWriter(Fixed_FILENAME);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "<SemiconductorTestDataNotification>")
                    {
                        line = line.Replace(">", 
                            " xmlns:ssdh=\"urn:rosettanet:specification:system:StandardDocumentHeader:xsd:schema:01.13\"" +
                            " xmlns:dm=\"urn:rosettanet:specification:domain:Manufacturing:xsd:schema:01.14\"" +
                            " >");
                    }
                    writer.WriteLine(line);
                }
                reader.Close();
                writer.Flush();
                writer.Close();
                XDocument doc = XDocument.Load(Fixed_FILENAME);
            }
        }
     
    }
                
