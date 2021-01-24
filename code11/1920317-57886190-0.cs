    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication131
    {
        class Program
        {
            const string INPUT_XML1 = @"c:\temp\test.xml";
            const string INPUT_XML2 = @"c:\temp\test1.xml";
            const string OUTPUT_XML = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument doc1 = XDocument.Load(INPUT_XML1);
                XElement body1 = doc1.Descendants("body").FirstOrDefault();
                XDocument doc2 = XDocument.Load(INPUT_XML2);
                XElement body2 = doc2.Descendants("body").FirstOrDefault();
                var query1 = (from d1 in body1.Elements()
                             join d2 in body2.Elements() on d1.ToString() equals d2.ToString() into p
                             from d2 in p.DefaultIfEmpty()
                             select new { d1 = d1, d2 = p == null ? null : d2 })
                             .Where(x => x.d2 == null)
                             .Select(x => x.d1)
                             .ToList();
                var query2 = (from d2 in body2.Elements()
                              join d1 in body1.Elements() on d2.ToString() equals d1.ToString() into p
                              from d1 in p.DefaultIfEmpty()
                              select new { d2 = d2, d1 = p == null ? null : d1 })
                              .Where(x => x.d1 == null)
                              .Select(x => x.d2)
                              .ToList();
                XElement newBody = new XElement("body", query1);
                newBody.Add(query2);
                body1.ReplaceWith(newBody);
                doc1.Save(OUTPUT_XML);
            }
        }
     
    }
