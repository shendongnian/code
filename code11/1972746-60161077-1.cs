    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XElement doc = new XElement("Root");
                doc.Add(XElement.Parse(xml));
                XElement dirProfiles = doc.Descendants("DirProfiles").FirstOrDefault();
                XElement profileInfo = dirProfiles.Element("ProfileInfo");
                profileInfo.SetAttributeValue("ProfileName", "Control1");
                profileInfo.SetAttributeValue("JobPath", @"D:\Client1\JobsA");
                profileInfo.SetAttributeValue("DatabasePath", @"D:\Database\Control1");
            }
        }
    }
