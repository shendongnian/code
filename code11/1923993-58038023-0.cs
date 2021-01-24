    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XNamespace ns = doc.Root.GetDefaultNamespace();
                Dictionary<string,string> dict = doc.Descendants(ns + "Field")
                    .GroupBy(x => (string)x.Attribute("element"), y => (string)y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
                MailingFolder folder = new MailingFolder()
                {
                    Folder_id = int.Parse(dict["folder_id"]),
                    Is_Deleted = dict["is_deleted"] == "0" ? false : true,
                    Name = dict["name"]
                };
             }
        }
        public class MailingFolder
        {
            public int Folder_id { get; set; }
            public bool Is_Deleted { get; set; }
            public string Name { get; set; }
        }
    }
