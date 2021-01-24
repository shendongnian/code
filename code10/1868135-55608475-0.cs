    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication108
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants("PasswordSettings").Select(x => new
                {
                    c = (string)x.Element("CustomerRef"),
                    node = (string)x.Element("Node"),
                    name = (string)x.Element("Name"),
                    login = (string)x.Element("Login"),
                    password = (string)x.Element("Password"),
                    fileType = (string)x.Element("FileType")
                }).ToList();
     
            }
        }
    }
