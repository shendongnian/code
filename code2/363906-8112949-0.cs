    List<XmlElement> errorElements = new List<XmlElement>();
    serializedObject.Validate((sender, args) =>
    {
        var exception = (args.Exception as XmlSchemaValidationException);
        if (exception != null)
        {
            var element = (exception.SourceObject as XmlElement);
            if (element != null)
                errorElements.Add(new XmlValidationError(element));
         }
    });
    foreach element in errorElements
    {
        var si = element.GetSchemaInfo
    }
