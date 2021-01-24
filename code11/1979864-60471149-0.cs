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
            static void Main(string[] args)
            {
                string xml = "<?xml version=\"1.0\"?>" +
                               "<env:Envelope" +
                                  " xmlns:ns3=\"http://rgwspublic2/RgWsPublic2\"" +
                                  " xmlns:ns2=\"http://rgwspublic2/RgWsPublic2Service\"" +
                                  " xmlns:ns1=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"" +
                                  " xmlns:env=\"http://www.w3.org/2003/05/soap-envelope\">" +
                                "</env:Envelope>";
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace nsEnv = root.GetNamespaceOfPrefix("env");
                XNamespace ns1 = root.GetNamespaceOfPrefix("ns1");
                XNamespace ns2 = root.GetNamespaceOfPrefix("ns2");
                XNamespace ns3 = root.GetNamespaceOfPrefix("ns3");
                XElement header = new XElement(nsEnv + "Header", 
                        new XElement(ns1 + "Security",
                        new XElement(ns1 + "UsernameToken")));
                XElement usernameToken = header.Descendants(ns1 + "UsernameToken").FirstOrDefault();
                string username = "xxxxx";
                string password = "yyyy";
                
                usernameToken.Add(new XElement(ns1 + "Username", username));
                usernameToken.Add(new XElement(ns1 + "Password", password));
                
                root.Add(header);
                XElement body = new XElement(nsEnv + "Body",
                                new XElement(ns2 + "rgWsPublic2AfmMethod",
                                new XElement(ns2 + "INPUT_REC")));
                XElement inputRec = body.Descendants(ns2 + "INPUT_REC").FirstOrDefault();
                root.Add(body);
                string afmCalledFor = "xxxxxxxxx";
                inputRec.Add(new XElement(ns3 + "afm_called_by"));
                inputRec.Add(new XElement(ns3 + "afm_called_for", afmCalledFor));
            }
        }
    }
