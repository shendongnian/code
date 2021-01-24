    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication128
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("cu", "http://www.mywebsite.com/test");
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(Customer));
                CustomerController controller = new CustomerController();
                serializer.Serialize(writer, controller.Get(), namespaces);
            }
        }
        public class ApiController
        {
        }
        public class CustomerController : ApiController
        {
            public Customer Get()
            {
                return new Customer { Name = "Mike", Age = 22.0M };
            }
        }
        [XmlRoot(ElementName = "Customer", Namespace = "http://www.mywebsite.com/test")]
        public class Customer
        {
            [XmlElement(Namespace = "")]
            public string Name { get; set; }
            [XmlElement(Namespace = "")]
            public decimal Age { get; set; }
        }
    }
