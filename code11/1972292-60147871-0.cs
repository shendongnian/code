    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                int maxParameters = doc.Descendants("Param").Max(x => x.Elements("Value").Count());
                DataTable dt = new DataTable();
                dt.Columns.Add("Parameters", typeof(string));
                for (int i = 1; i <= maxParameters; i++)
                {
                    dt.Columns.Add("Value#" + i.ToString(), typeof(string));
                }
                foreach (XElement param in doc.Descendants("Param"))
                {
                    List<string> row = new List<string>() { (string)param.Attribute("name")};
                    row.AddRange(param.Elements("Value").Select(x => (string)x));
                    dt.Rows.Add(row.ToArray());
                }
            }
        }
    }
