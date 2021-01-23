    class XmlValidationFailedException : Exception {
       public XmlValidationFailedException(string message, Exception innerException) : base(message, innerException) {}
    }
    private static void Handler(object sender, ValidationEventArgs e)
    {
    
        if (e.Severity == XmlSeverityType.Error || e.Severity == XmlSeverityType.Warning)
        {
            string message = String.Format("Line: {0}, Position: {1} \"{2}\"",
                         e.Exception.LineNumber, e.Exception.LinePosition, e.Exception.Message)
            throw new XmlValidationFailedException(message);
        }
