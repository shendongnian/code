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
                List<string> items = new List<string>(){ "Item1", "Item2", "Item3"};
                string xml = 
                    "<soapenv:Envelope  xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org\"" +
                          " xmlns:arr=\"http://schemas.microsoft.com/2003/10/Serialization/Arrays\">" +
                         "<soapenv:Header/>" +
                          "<soapenv:Body>" +
                          "<tem:request>" +
                             "<tem:id>1</tem:id>" +
                             "<tem:list>" +
                             "</tem:list>" +
                          "</tem:request>" +
                       "</soapenv:Body>" +
                      "</soapenv:Envelope>";
                XDocument doc = XDocument.Parse(xml);
                XElement root = doc.Root;
                XNamespace temNs = root.GetNamespaceOfPrefix("tem");
                XNamespace arrNs = root.GetNamespaceOfPrefix("arr");
                XElement list = doc.Descendants(temNs + "list").FirstOrDefault();
                List<XElement> xItems = items.Select(x => new XElement(arrNs + "string", x)).ToList();
                list.Add(xItems);
                doc.Save(FILENAME);
            }
        }
    }
