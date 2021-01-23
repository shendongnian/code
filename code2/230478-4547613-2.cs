    using System.Xml;        // for XmlTextReader and XmlValidatingReader
    using System.Xml.Schema; // for XmlSchemaCollection (which is used later)
    internal class Program
    {
        private static
            bool isValid = true; // If a validation error occurs,
                                 // set this flag to false in the
                                 // validation event handler. 
        private static void Main(string[] args)
        {
            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.ValidationType = ValidationType.Schema;
            xrs.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            xrs.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            xrs.ValidationEventHandler += MyValidationEventHandler;
            XmlReader r = XmlReader.Create("<path to xml>", xrs);
            while (r.Read())
            {
                // Can add code here to process the content.
            }
            r.Close();
            // Check whether the document is valid or invalid.
            Console.WriteLine(isValid ? "Document is valid" : "Document is invalid");
            Console.In.ReadLine();
        }
        public static void MyValidationEventHandler(object sender,
                                                    ValidationEventArgs args)
        {
            Console.Out.WriteLine("Validation {1}: {0}", args.Message, args.Severity);
            isValid = false;
        }
    }
