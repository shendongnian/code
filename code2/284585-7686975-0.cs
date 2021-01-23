    var settings = new XmlReaderSettings();
    
    settings.Schemas.Add(_schemas);
    settings.CloseInput = true;
    settings.ValidationType = ValidationType.Schema;
    settings.ValidationFlags = XmlSchemaValidationFlags.AllowXmlAttributes
                             | XmlSchemaValidationFlags.ProcessInlineSchema
                             | XmlSchemaValidationFlags.ReportValidationWarnings;
    settings.ValidationEventHandler += ValidationEventHandler;
    
    
    using (XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents())
    using (XmlReader documentReader = XmlReader.Create(bodyReader.ReadSubtree(), settings))
    {
    	documentReader.MoveToContent();
        using (var memory = new MemoryStream())
    	//copy & validate in one step :)    
    	using (XmlWriter writer = XmlWriter.Create(memory))
    	{
    		writer.WriteNode(documentReader, false);
    		writer.Flush();
    	}
    #if DEBUG    
    	memory.Seek(0, SeekOrigin.Begin);
    	string xml = new StreamReader(memory).ReadToEnd();
    #endif
    	memory.Seek(0, SeekOrigin.Begin);
    
    	message = Message.CreateMessage(message.Version, null, XmlReader.Create(memory));
    	message.Headers.CopyHeadersFrom(message);
    }
