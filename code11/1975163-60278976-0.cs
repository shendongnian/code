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
            const string INPUT_FILENAME1 = @"c:\temp\test.xml";
            const string INPUT_FILENAME2 = @"c:\temp\test1.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument doc1 = XDocument.Load(INPUT_FILENAME1);
                XDocument doc2 = XDocument.Load(INPUT_FILENAME2);
                var compareItems = (from bore in doc1.Descendants("WellBore")
                               join permit in doc2.Descendants("DrillingPermit") on (string)bore.Element("APINumber") equals (string)permit.Element("APINumber")
                                   select new { bore = bore, permit = permit}).ToList();
                foreach (var compareItem in compareItems)
                {
                    compareItem.bore.AddAfterSelf(compareItem.permit);
                }
                doc1.Save(OUTPUT_FILENAME);
            }
     
        }
    }
