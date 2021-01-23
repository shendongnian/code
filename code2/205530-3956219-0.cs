        using System;
    using System.Xml;
    
    namespace XMLTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlDocument doc = new XmlDocument();
                 XmlNamespaceManager namespaces = new XmlNamespaceManager(doc.NameTable);
                namespaces.AddNamespace("ns1", "jabber:client");
                namespaces.AddNamespace("ns2", "http://jabber.org/protocol/pubsub");
                doc.Load("xmltest.xml");
                XmlNode iqNode = doc.SelectSingleNode("/ns1:iq", namespaces);
                string ID = iqNode.Attributes["id"].Value;
                Console.WriteLine(ID);
 
                XmlNode subscriptionNode = doc.SelectSingleNode("/ns1:iq/ns2:pubsub/ns2:subscription", namespaces);
                string subID = subscriptionNode.Attributes["subid"].Value;
                Console.WriteLine(subID);
    
                Console.ReadLine();
            }
        }
    }
