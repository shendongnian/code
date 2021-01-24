    private static XmlWriter xmlWriter;
    public void Write()
    {
    	xmlWriter = XmlWriter.Create(Path);
    	xmlWriter.WriteStartDocument();
    	xmlWriter.WriteStartElement("Config");
    	
    	new List<elementDataType> // note that you need to change "elementDataType" to your elements data type
    	{
    		TBSOMS,
    		TBWVB,
    		// ... just list all elements in here
    	}.ForEach(elem => WriteElement(elem));
    
    	
    	xmlWriter.WriteEndDocument();
    	xmlWriter.Close();
    }
    
    private void WriteElement(var element) //note that you need to change var to your elements datatype
    {
    	xmlWriter.WriteStartElement(nameof(element));
    	xmlWriter.WriteString(element.Text);
    	xmlWriter.WriteEndElement();
    }
