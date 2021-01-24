	var errors = new List<XmlSchemaValidationException>();
	ValidationEventHandler callback = (sender, args) =>
	{
		var exception = (args.Exception as XmlSchemaValidationException);
		if (exception != null)
		{
			errors.Add(exception);
		}
	};			
	doc.Validate(schema, callback, true);			
	
	foreach (var exception in errors)
	{
		// Handle the exception itself.
		Console.WriteLine(exception);
	}
	
	if (errors.Count > 0)
	{
		// If there were any errors, traverse the entire document looking for invalid nodes:
		DumpInvalidNodes(doc.Root);
	}
