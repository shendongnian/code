    private DataTable xmlErrors;
    [WebMethod]
    public string Upload(byte[] f, string fileName) {
    	string ret = "This will have the response";
    
    	// this is the namespace that we want to use
    	string xmlNs = "http://mydomain.com/ns/upload.xsd";
        // you could put a public url of xsd instead of a local file
    	string xsdFileName = Server.MapPath("~") + "//" +"shiporder.xsd"; 
    
        // a simple table to store the eventual errors 
        // (more advanced ways possibly exist)
    	xmlErrors = new DataTable("XmlErrors");
    	xmlErrors.Columns.Add("Type");
    	xmlErrors.Columns.Add("Message");
    
    	try {
    		XmlDocument doc = new XmlDocument(); // create a document
                
    		// bind the document, namespace and xsd
    		doc.Schemas.Add(xmlNs, xsdFileName); 
                
    		// if we wanted to validate if the XSD has itself XML errors
    		// doc.Schemas.ValidationEventHandler += 
    		// new ValidationEventHandler(Schemas_ValidationEventHandler);
    		// Declare the handler that will run on each error found
    		ValidationEventHandler xmlValidator = 
    			new ValidationEventHandler(Xml_ValidationEventHandler);
    		// load the document 
    		// will trhow XML.Exception if document is not "well formed"
    		doc.Load(new MemoryStream(f));
            // Check if the required namespace is present
            if (doc.DocumentElement.NamespaceURI == xmlNs) {
                
    			// Validate against xsd 
	    		// will call Xml_ValidationEventHandler on each error found
                doc.Validate(xmlValidator);
                if (xmlErrors.Rows.Count == 0) {
                    ret = "OK";
                } else {
    				// return the complete error list, this is just to proove it works
    				ret = "File has " + xmlErrors.Rows.Count + " xml errors ";
    				ret += "when validated against our XSD.";
                }
            } else {
                ret = "The xml document has incorrect or no namespace.";                
            }
    	} catch (XmlException ex) {
    		ret = "XML Exception: probably xml not well formed... ";
    		ret += "Message = " + ex.Message.ToString();
    	} catch (Exception ex) {
    		ret = "Exception: probably not XML related... "
    		ret += "Message = " + ex.Message.ToString();
    	}
    	return ret;
    }
    
    private void Xml_ValidationEventHandler(object sender, ValidationEventArgs e) {
    	xmlErrors.Rows.Add(new object[] { e.Severity, e.Message });
    }
