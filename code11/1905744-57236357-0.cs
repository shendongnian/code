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
                XNamespace ns0 = doc.Root.GetNamespaceOfPrefix("ns0");
                XElement sender = doc.Descendants(ns0 + "SenderNameAndAddress").FirstOrDefault();
                string[] senderAddress = sender.Descendants(ns0 + "Address").Elements().Select(x => (string)x).ToArray();
                XElement recipientDeliveries = doc.Descendants(ns0 + "RecipientDeliveries").FirstOrDefault();
                var results = recipientDeliveries.Elements(ns0 + "Recipient").Select(x => new
                {
                    name = (string)x.Descendants(ns0 + "Name").FirstOrDefault(),
                    address = x.Descendants(ns0 + "Address").Elements().Select(y => (string)y).ToArray(),
                    deliveries = x.Descendants(ns0 + "Delivery").Select(y => new {
                        deliveryID = (string)y.Descendants(ns0 + "DeliveryID").FirstOrDefault(),
                        deliveryType = (string)y.Descendants(ns0 + "DeliveryType").FirstOrDefault(),
                        deliveryRoute = (string)y.Descendants(ns0 + "DeliveryRoute").FirstOrDefault(),
                        toteID = (string)y.Descendants(ns0 + "ToteID").FirstOrDefault(),
                        nursingStation = (string)y.Descendants(ns0 + "NursingStation").FirstOrDefault()
                    }).ToList()
                }).ToList();
            }
        }
    }
