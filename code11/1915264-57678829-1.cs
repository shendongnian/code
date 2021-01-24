    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(InvoicesDoc));
                InvoicesDoc doc = new InvoicesDoc()
                {
                    invoice = new AadeBookInvoiceType[] {
                        new AadeBookInvoiceType() 
                        {
                        }
                    }
                };
                serializer.Serialize(writer, doc);
            }
        }
        public class InvoicesDoc
        {
            [XmlElement(ElementName = "invoice")]
            public AadeBookInvoiceType[] invoice { get; set; }
        }
        [XmlRoot(ElementName = "invoice")]
        public class AadeBookInvoiceType
        {
            //add the rest of the invoice properties here
        }
    }
