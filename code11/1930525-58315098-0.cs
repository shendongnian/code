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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<Card> cards = doc.Descendants().Where(x => (x.Name.LocalName == "Card") || (x.Name.LocalName == "SubType"))
                    .Select(x => new Card()
                    {
                        DccCardIssueNumber = (string)x.Element("DccCardIssueNumber") + (string)x.Element("DccCardIssueSubTypeNumber"),
                        DccCardIssuerName = (string)x.Element("DccCardIssuerName") + (string)x.Element("DccCardIssueSubTypeName"),
                        DccCardIssuerFullName = (string)x.Element("DccCardIssuerFullName") + (string)x.Element("DccCardIssueSubTypeFullName"),
                        RPOSCardType = (string)x.Element("RPOSCardType"),
                        DeliveryNote = (string)x.Element("DeliveryNote")
                    }).ToList();
                Dictionary<string, List<Card>> dict = cards.GroupBy(x => x.DccCardIssueNumber, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
        public class Card
        {
            public string DccCardIssueNumber { get; set; }
            public string DccCardIssuerName { get; set; }
            public string DccCardIssuerFullName { get; set; }
            public string RPOSCardType { get; set; }
            public string DeliveryNote { get; set; }
        }
    }
