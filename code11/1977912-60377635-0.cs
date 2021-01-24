    class Program
    {
        static void Main(string[] args)
        {
            var result = ValidateXml("<Person id=\"22\"><Name>John<Name></Person>");
            if (!result.IsValid)
            {
                Console.WriteLine($"Line number: {result.Exception.LineNumber}");
                Console.WriteLine($"Line position: {result.Exception.LinePosition}");
                Console.WriteLine($"Message: {result.Exception.Message}");
            }
    
            // OUTPUT:
            // Line number: 1
            // Line position: 35
            // Message: The 'Name' start tag on line 1 position 28 does not match the end tag of 'Person'.Line 1, position 35.
        }
    
        static ValidationResult ValidateXml(string xml)
        {
            using (var xr = XmlReader.Create( new StringReader(xml)))
            {
                try
                {
                    while (xr.Read())
                    {
                    }
    
                    return ValidationResult.ValidResult;
                }
                catch (XmlException exception)
                {
                    return new ValidationResult(exception);
                }
            }
        }
    
        public class ValidationResult
        {
            public static ValidationResult ValidResult = new ValidationResult();
    
            private ValidationResult()
            {
                IsValid = true;
            }
    
            public ValidationResult(XmlException exception)
            {
                IsValid = false;
                Exception = exception;
            }
    
            public bool IsValid { get; }
    
            public XmlException Exception { get;}
        }
    }
