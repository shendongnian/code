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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                var results = doc.Descendants()
                    .Where(x => x.Name.LocalName == "p")
                    .Select(x => x.Descendants().Where(y => y.Name.LocalName == "t")
                        .Select(z => new
                        {
                            paraId = (string)x.Attributes().Where(y => y.Name.LocalName == "paraId").FirstOrDefault(),
                            text = (string)z
                        })
                        ).Where(y => y.Count() > 0).Select(y => new { paraId = y.First().paraId, text = string.Join("", y.Select(z => z.text))})
                        .ToList();
            }
        }
    }
