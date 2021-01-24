    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication108
    {
        class Program
        {
            const string XML_FILENAME = @"c:\temp\test.xml";
            const string TEXT_FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(XML_FILENAME);
                StreamWriter writer = new StreamWriter(TEXT_FILENAME);
                while (!reader.EOF)
                {
                    if (reader.Name != "KeyFamily")
                    {
                        reader.ReadToFollowing("KeyFamily");
                    }
                    if (!reader.EOF)
                    {
                        XElement keyFamily = (XElement)XElement.ReadFrom(reader);
                        string id = (string)keyFamily.Attribute("id");
                        string agencyID = (string)keyFamily.Attribute("agencyID");
                        writer.WriteLine("id = {0}, agencyID = {1}", id, agencyID);
                    }
                }
                writer.Flush();
                writer.Close();
     
            }
        }
     
      
    }
