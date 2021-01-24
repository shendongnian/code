	var errors = new List<XmlSchemaValidationException>();
	ValidationEventHandler callback = (sender, args) =>
	{
		var exception = (args.Exception as XmlSchemaValidationException);
		if (exception != null)
		{
			errors.Add(exception);
		}
	};			
	
	var navigator = doc.CreateNavigator();
	navigator.CheckValidity(schema, callback);			
	
	foreach (var exception in errors)
	{
		var node = (XObject)exception.SourceObject;
		
		// Do something with the node.
		Console.WriteLine();
		Console.WriteLine(exception);
		Console.WriteLine("{0}: {1}", node.GetType(), node.ToString());
		Assert.IsTrue(node != null, "node != null");
	}
