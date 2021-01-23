    public class XmlValidator
    {
        private bool _isValid = true;
        public bool Validate(string xml)
        {
            _isValid = true;
            // Set the validation settings as needed.
            var settings = new XmlReaderSettings { ValidationType = ValidationType.Schema };
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += ValidationCallBack;
            var reader = XmlReader.Create(new StringReader(xml), settings);
            while(reader.Read())
            {
                // process the content if needed
            }
            return _isValid;
        }
        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            // check for severity as needed
            if(e.Severity == XmlSeverityType.Error)
            {
                _isValid = false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new XmlValidator();
            var result =
                validator.Validate(@"<?xml version=""1.0""?>
                     <Product ProductID=""1"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""schema.xsd"">
                         <ProductName>Chairs</ProductName>
                     </Product>");
    }
