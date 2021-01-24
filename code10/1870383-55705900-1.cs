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
            const string URL = "https://stats.oecd.org/restsdmx/sdmx.ashx/GetDataStructure/all";
            const string TEXT_FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.CheckCharacters = false;
                //XmlReader reader = XmlReader.Create(XML_FILENAME, settings);
                XmlReader reader = XmlReader.Create(URL, settings);
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
                        List<string> columns = new List<string>();
                        columns.Add((string)keyFamily.Attribute("id"));
                        //string agencyID = (string)keyFamily.Attribute("agencyID");
                        columns.AddRange(keyFamily.Elements().Where(x => x.Name.LocalName == "Name").Select(x => (string)x));
                        writer.WriteLine(string.Join("|", columns));
                    }
                }
                writer.Flush();
                writer.Close();
     
            }
        }
     
      
    }
