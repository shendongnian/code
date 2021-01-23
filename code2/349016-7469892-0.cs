                List<XmlElement> errorElements = new List<XmlElement>();
    
                serializedObject.Validate((x, y) =>
                {
                    var exception = (y.Exception as XmlSchemaValidationException);
    
                    if (exception != null)
                    {
                        var element = (exception.SourceObject as XmlElement);
    
                        if (element != null)
                            errorElements.Add(new XmlValidationError(element));
                    }
    
                });
