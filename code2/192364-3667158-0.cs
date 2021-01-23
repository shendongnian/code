    var settings = new XmlSettings {
      ConfirmanceLevel = ConfirmanceLevel.Document,
      ValidationType = ValidationType.Schema,
      ValidationFlags = ValidationFlags.ProcessSchemaLocation|ValidationFlags.ProcessInlineSchema,
    };
    int warnings = 0;
    int errors = 0;
    settings.ValidationEventHandler += (obj, ea) => {
      if (args.Severity==XmlSeverityType.Warning) {
        +warnings;
      } else {
        ++errors;
      }
    };
    XmlReader xvr = XmlReader.Create(new StringReader(inputDocInString, settings);
    
    try {
    	while (xvr.Read()) {
    		// do nothing
    	}
    	if (0 != errors) {
    		Console.WriteLine("\nFailed to load XML, {0} error(s) and {1} warning(s).", errors, warnings);
    	} else if (0 != warnings) {
    		Console.WriteLine("\nLoaded XML with {0} warning(s).", warnings);
    	} else {
    		System.Console.WriteLine("Loaded XML OK");
    	}
    
    	Console.WriteLine("\nSchemas loaded durring validation:");
    	ListSchemas(xvr.Schemas, 1);
    
    } catch (System.Xml.Schema.XmlSchemaException e) {
    	System.Console.Error.WriteLine("Failed to read XML: {0}", e.Message);
    
    } catch (System.Xml.XmlException e) {
    	System.Console.Error.WriteLine("XML Error: {0}", e.Message);
    
    } catch (System.IO.IOException e) {
    	System.Console.Error.WriteLine("IO error: {0}", e.Message);
    }
