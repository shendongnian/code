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
                DateTime dt = DateTime.Today.AddHours(17);
                string datetime = dt.ToString("yyyy-MM-ddTHH:mm:ss");
                XDocument doc = XDocument.Load(FILENAME);
                XElement date = doc.Descendants("ProductLastModifiedDate").FirstOrDefault();
                date.SetValue(datetime);
                doc.Save(FILENAME);
     
            }
        }
    }
     
