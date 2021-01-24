    private static XmlWriter xmlWriter;
    public void Write()
    {
    	xmlWriter = XmlWriter.Create(Path);
    	xmlWriter.WriteStartDocument();
    	xmlWriter.WriteStartElement("Config");
    	
    	new List<(elementDataType element, string name)> // note that you need to change "elementDataType" to your elements data type
    	{
    		(TBSOMS, nameof(TBSOMS)),
    		(TBWVB, nameof(TBWVB)),
    		// ... just list all elements in here
    	}.ForEach(elem => WriteElement(elem.element, elem.name));
    
    	
    	xmlWriter.WriteEndDocument();
    	xmlWriter.Close();
    }
    
    private void WriteElement(var element, string name) //note that you need to change var to your elements datatype
    {
    	xmlWriter.WriteStartElement(name);
    	xmlWriter.WriteString(element.Text);
    	xmlWriter.WriteEndElement();
    }
