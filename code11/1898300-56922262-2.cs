    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass myClass = new MyClass();
                XDocument doc = MySerializer<MyClass>.GetXElement(myClass);
            }
        }
        public class MySerializer<T> where T : new()
        {
            static string xml =
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
            public static XDocument GetXElement(T myClass)
            {
     
                XDocument doc = XDocument.Parse(xml);
                XElement results = doc.Descendants().Where(x => x.Name.LocalName == "Results").FirstOrDefault();
                XNamespace ns_b = results.GetNamespaceOfPrefix("b");
                StringWriter sWriter = new StringWriter();
                XmlWriter xWriter = XmlWriter.Create(sWriter);
                XmlSerializerNamespaces ns1 = new XmlSerializerNamespaces();
                ns1.Add("b", ns_b.NamespaceName);
                XmlSerializer serializer = new XmlSerializer(typeof(T), ns_b.NamespaceName);
                serializer.Serialize(xWriter, myClass, ns1);
                results.Add(XElement.Parse(sWriter.ToString()));
                return doc;
            }
        }
        public class MyClass
        {
            public string test { get; set; }
        }
    }
