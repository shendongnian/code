    public void WriteXml(System.Xml.XmlWriter writer)
    {
    	// Used while Serialization
    
    	// Serialize each BizEntity this collection holds
    	foreach( string key in this.Dictionary.Keys )
    	{
    		Serializer.Serialize(writer, this.Dictionary[key]);
    	}
    }
    
    public void ReadXml(System.Xml.XmlReader reader)
    {
    	// Used while Deserialization
    
    	// Move past container
    	reader.Read();
    
    	// Deserialize and add the BizEntitiy objects
    	while( reader.NodeType != XmlNodeType.EndElement )
    	{
    		BizEntity entity;
    
    		entity = Serializer.Deserialize(reader) as BizEntity;
    		reader.MoveToContent();
    		this.Dictionary.Add(entity.Key, entity);
    	}
    }
