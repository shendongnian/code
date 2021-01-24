    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication120
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("align", typeof(string));
                dt.Columns.Add("value", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement p in doc.Descendants("p"))
                {
                    dt.Rows.Add(new object[] {
                        (string)p.Attribute("align"),
                        (string)p
                    });
                }
            }
     
        }
    }
