    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication143
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                //from sampleon following webpage
                //https://zappysys.com/blog/get-data-from-workday-in-ssis-using-soap-or-rest-api/
                //<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:bsvc="urn:com.workday/bsvc">
                //   <soapenv:Header/>
                //   <soapenv:Body>
                //      <bsvc:Employee_Get>
                //         <bsvc:Employee_Reference>
                //            <bsvc:Integration_ID_Reference>
                //               <bsvc:ID>gero et</bsvc:ID>
                //            </bsvc:Integration_ID_Reference>
                //         </bsvc:Employee_Reference>
                //      </bsvc:Employee_Get>
                //   </soapenv:Body>
                //</soapenv:Envelope>
                Envelope envelope = new Envelope()
                {
                    header = new Header(),
                    body = new Body()
                    {
                        employee_Get = new Employee_Get()
                        {
                            employee_Reference = new Employee_Reference()
                            {
                                integration_ID_Reference = new Integration_ID_Reference()
                                {
                                    ID = "gero et"
                                }
                            }
                        }
                    }
                };
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("bsvc", "urn:com.workday/bsvc");
                namespaces.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                serializer.Serialize(writer, envelope, namespaces);
     
            }
        }
        [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Envelope
        {
            [XmlElement(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public Header header { get; set; }
            [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public Body body { get; set; }
        }
        [XmlRoot(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Header
        {
        }
        [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Body
        {
            [XmlElement(ElementName = "Employee_Get", Namespace = "urn:com.workday/bsvc")]
            public Employee_Get employee_Get { get; set; }
        }
        [XmlRoot(ElementName = "Employee_Get", Namespace = "urn:com.workday/bsvc")]
        public class Employee_Get
        {
            [XmlElement(ElementName = "Employee_Reference", Namespace = "urn:com.workday/bsvc")]
            public Employee_Reference employee_Reference { get; set; }
        }
        [XmlRoot(ElementName = "Employee_Reference", Namespace = "urn:com.workday/bsvc")]
        public class Employee_Reference
        {
            [XmlElement(ElementName = "Integration_ID_Reference", Namespace = "urn:com.workday/bsvc")]
            public Integration_ID_Reference integration_ID_Reference { get; set; }
        }
        [XmlRoot(ElementName = "Integration_ID_Reference", Namespace = "urn:com.workday/bsvc")]
        public class Integration_ID_Reference
        {
            [XmlElement(ElementName = "ID", Namespace = "urn:com.workday/bsvc")]
            public string ID { get; set; }
        }
     
