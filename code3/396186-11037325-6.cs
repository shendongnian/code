    private DataTable xmlErrors;
    [WebMethod]
    public string Upload(byte[] f, string fileName) {
    	string ret = "This will have the response";
    
    	// this is the namespace that we eant to use
    	string xmlNs = "http://mydomain.com/ns/upload.xsd";
        // you could put a public url of xsd instead of a local file
    	string xsdFileName = Server.MapPath("~") + "//" +"shiporder.xsd"; 
    
        // a simple table to store the eventual errors (more advanced way possibly exist)
    	xmlErrors = new DataTable("XmlErrors");
    	xmlErrors.Columns.Add("Type");
    	xmlErrors.Columns.Add("Message");
    
    	try {
    		XmlDocument doc = new XmlDocument(); // create a document
    		doc.Schemas.Add(xmlNs, xsdFileName); // bind the document, namespace and xsd
                
    		// if we wanted to validate if the XSD has itself XML errors
    		// doc.Schemas.ValidationEventHandler += new ValidationEventHandler(Schemas_ValidationEventHandler);
    		// Declare the handler that will run on each error found
    		ValidationEventHandler xmlValidator = new ValidationEventHandler(Xml_ValidationEventHandler);
    		// load the document 
    		// will trhow XML.Exception if document is not "well formed"
    		doc.Load(new MemoryStream(f));
    		// Validate against xsd (if it is defined on the XML, we don't kow yet)
    		// will call Xml_ValidationEventHandler on each error found
    		doc.Validate(xmlValidator);
    
    		if (xmlErrors.Rows.Count == 0) {
    			/* No errors, could be because it is correct or... validated 
    			 * validated against the wrong namespace, so.. we must
    			 * Check the required namespace was present (therefore used) */
    			if (doc.NamespaceURI == xmlNs) {
    			       /* Continue processing the file... */
    				ret = "OK";
    			} else {
    				ret = "The xml document has incorrect or no namespace.";
    			}
    		} else {
    			// return the complete error list, this is just to proove it works
    			ret = "The file has " + xmlErrors.Rows.Count + " xml errors when validated against our XSD.";
    		}
    	} catch (XmlException ex) {
    		ret = "XML Exception: probably xml not well formed... Message=" + ex.Message.ToString();
    	} catch (Exception ex) {
    		ret = "Exception: probably not XML related... Message=" + ex.Message.ToString();
    	}
    	return ret;
    }
    
    private void Xml_ValidationEventHandler(object sender, ValidationEventArgs e) {
    	xmlErrors.Rows.Add(new object[] { e.Severity, e.Message });
    }
