    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication103
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("version", typeof(string));
                dt.Columns.Add("sha1sum", typeof(string));
                dt.Columns.Add("url", typeof(string));
                dt.Columns.Add("ps3_system_ver", typeof(string));
                dt.Columns.Add("size", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement addresdm in doc.Descendants("package"))
                {
                     dt.Rows.Add(new object[] {
                        (string)addresdm.Attribute("version"),
                        (string)addresdm.Attribute("sha1sum"),
                        (string)addresdm.Attribute("url"),
                        (string)addresdm.Attribute("ps3_system_ver"),
                        (string)addresdm.Attribute("size"),
                    });
                }
     
            }
        }
     
    }
