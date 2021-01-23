    List<XElement> errorElements = new List<XElement>();
    serializedObject.Validate((sender, args) =>
    {
        var exception = (args.Exception as XmlSchemaValidationException);
        if (exception != null)
        {
            var element = (exception.SourceObject as XElement);
            if (element != null)
                errorElements.Add(element);
         }
    });
    foreach (var element in errorElements)
    {
        var si = element.GetSchemaInfo(); 
        
        // do something with SchemaInfo
    }
