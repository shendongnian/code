    public static void CreateProfilesFile (string path) {
		Debug.Log("create init");      // This line wasn't called the second time ... 
		
		if (System.IO.File.Exists(path)) return;
		
		// Create a new file specified path
       	XmlTextWriter textWriter = new XmlTextWriter(path,null);
       	// Opens the document
       	textWriter.WriteStartDocument();
       	// Write comments
       	textWriter.WriteComment("This document contains the profiles that have been created.");
		textWriter.WriteStartElement("Profiles");
			textWriter.WriteStartElement("Profile");
				textWriter.WriteStartElement("user");
					textWriter.WriteString("foo user");
				textWriter.WriteEndElement();
				textWriter.WriteStartElement("url");
					textWriter.WriteString("foo url");
				textWriter.WriteEndElement();		
				textWriter.WriteStartElement("password");
					textWriter.WriteString("foo password");
				textWriter.WriteEndElement();
			textWriter.WriteEndElement();
		textWriter.WriteEndElement();
       	// Ends the document.
       	textWriter.WriteEndDocument();
       	// close writer
       	textWriter.Close();
	}
