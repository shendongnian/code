    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace XML
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement EmpDetail = doc.Descendants("EmpDetail").Where(x => (int)x.Element("RecordId") == 2).FirstOrDefault();
                EmpDetail.Remove();
     
            }
        }
    }
     
