    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication151
    {
        class Program
        {
            static void Main(string[] args)
            {
                string user = "jsmith";
                string password = "abcdefg";
                string inputs =
                    "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                        "<soap:Header xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                            "<wes:auth xmlns:wes=\"http://asdf.org\">" +
                            "</wes:auth>" +
                        "</soap:Header>" +
                        "<soapenv:Body>" +
                            "<get:GetCustomer xmlns:get=\"http://werty.org\">" +
                            "</get:GetCustomer>" +
                        "</soapenv:Body>" +
                    "</soapenv:Envelope>";
                XDocument doc = XDocument.Parse(inputs);
                XElement wes = doc.Descendants().Where(x => x.Name.LocalName == "auth").FirstOrDefault();
                List<XElement> authorization = new List<XElement>() {
                    new XElement("u", user),
                    new XElement("p", password)
                };
                wes.Add(authorization);
            }
        }
    }
