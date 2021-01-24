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
                XElement recipient = doc.Descendants(ns0 + "Recipient").FirstOrDefault();
                XElement recipientNameAndAddress = recipient.Descendants(ns0 + "RecipientNameAndAddress").FirstOrDefault();
                string[] recpientAddress = recipientNameAndAddress.Descendants(ns0 + "Address").Elements().Select(x => (string)x).ToArray();
                string[][] deliveries = recipient.Descendants(ns0 + "Delivery")
                    .Select(x => x.Elements().Select(y => (string)y).ToArray()).ToArray();
            }
        }
    }
