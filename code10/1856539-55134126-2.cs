    using System;
    using System.Xml;
    using System.Xml.Schema;
    
    namespace DtdValidation
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.ValidationType = ValidationType.DTD;
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
                settings.XmlResolver = new XmlUrlResolver();
    
                XmlDocument doc = new XmlDocument();
                XmlReader reader = XmlReader.Create("data.xml", settings);
                doc.Load(reader);
            }
    
            // Display any validation errors.
            private static void ValidationCallBack(object sender, ValidationEventArgs e)
            {
                Console.WriteLine("Validation Error: {0}", e.Message);
            }
        }
    }
