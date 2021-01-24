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
                 string xmlHeader = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><root></root>";
                 XDocument doc = XDocument.Parse(xmlHeader);
                 XElement root = doc.Root;
                 
                 XElement paymentmethodType = XElement.Parse("<PaymentMethod xmlns:xsi=\"w3.org/2001/XMLSchema-instance\" xsi:type=\"CreditTransferType\"/>");
                 root.Add(paymentmethodType);
                 doc.Save(FILENAME);
             }
        }
    }
