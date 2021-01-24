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
                XDocument doc = XDocument.Load(FILENAME);
                XElement productName = doc.Root;
                List<TopLevelObject> top = productName.Elements().Select(x => new TopLevelObject() {
                    Version = x.Name.LocalName,
                    Row = new RowLevelObject() {
                        Guid = (string)x.Element("GUID"),
                        VersionName = (string)x.Element("VersionNameToUninstall"),
                        UninstallFileName = (string)x.Element("UninstallResponseFile")
                    }
                }).ToList();
     
            }
        }
        public class TopLevelObject
        {
            public string Version { get; set; }
            public RowLevelObject Row { get; set; }
        }
        public struct RowLevelObject
        {
            public string Guid { get; set; }
            public string VersionName { get; set; }
            public string UninstallFileName { get; set; }
        }
    }
