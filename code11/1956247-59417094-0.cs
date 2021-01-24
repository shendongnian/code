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
                string[] xmlArray = {
                                        "<CustomerAdd>" +
                                          "<Name>Zohreh FAKELASTNAME</Name>" +
                                          "<Salutation>Mr</Salutation>" +
                                          "<FirstName>Zohreh</FirstName>" +
                                          "<LastName>FAKELASTNAME</LastName>" +
                                        "</CustomerAdd>",
                                        "<CustomerAdd>" +
                                          "<Name>Phillip FAKELASTNAME</Name>" +
                                          "<Salutation>Mr</Salutation>" +
                                          "<FirstName>Phillip</FirstName>" +
                                          "<LastName>FAKELASTNAME</LastName>" +
                                        "</CustomerAdd>"
                                    };
                XElement customerAddRq = new XElement("CustomerAddRq");
                customerAddRq.Add(xmlArray.Select(x => XElement.Parse(x)));
            }
        }
    }
