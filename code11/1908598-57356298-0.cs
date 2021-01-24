    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication124
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Parent Name", typeof(string));
                dt.Columns.Add("Child Name", typeof(string));
                dt.Columns.Add("GChild", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach(XElement parent in doc.Descendants("Parent"))
                {
                    string parentName = (string)parent.Attribute("Name");
                    foreach(XElement child in parent.Elements("Child"))
                    {
                        string childName = (string)child.Attribute("Name");
                        foreach (XElement gChild in child.Elements("GChild"))
                        {
                            string gChildStr = (string)gChild.Attribute("Name");
                            dt.Rows.Add(new object[] { parentName, childName, gChildStr });
                        }
                    }
                }
            }
        }
    }
