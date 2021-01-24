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
                List<string> data = new List<string>() {
                    "Kermit.The.Frog",
                    "Miss.Piggy"
                };
                string xml =
                    "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                    "    <s:Body>" +
                    "       <GetUsernamesResponse xmlns=\"http://tempuri.org/\">" +
                    "          <GetUsernamesResult xmlns:a=\"http://schemas.datacontract.org/2004/07/ConsoleApp2\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                    "             <a:Results xmlns:b=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\">" +
                    "             </a:Results>" +
                    "          </GetUsernamesResult>" +
                    "      </GetUsernamesResponse>" +
                    "   </s:Body>" +
                    "</s:Envelope>";
                XDocument doc = XDocument.Parse(xml);
                XElement results = doc.Descendants().Where(x => x.Name.LocalName == "Results").FirstOrDefault();
                XNamespace ns_b = results.GetNamespaceOfPrefix("b");
                foreach (string d in data)
                {
                    results.Add(new XElement(ns_b + "string", d));
                }
            }
        }
    }
