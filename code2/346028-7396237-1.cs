    public class YourClass : IXmlSerializable
    {
        [IsDirty(true)]
        public string Name { get; set; }
        
        // skipped ReadXml and GetSchema interface methods for brevity
        
        public void WriteXml(XmlWriter writer)
        {
        	writer.WriteStartElement("YourClass");
    
         	var myType = typeof(YourClass);
     	
     		foreach(var propInfo in myType.GetProperties())
     		{
     		    writer.WriteStartElement(propInfo.Name);
     		    foreach(var attr in propInfo.GetCustomAttributes(typeof(IsDirtyAttribute), false))
     		    {
     		    	var myAttr = attr as IsDirtyAttribute;
     		    	writer.WriteAttributeString("Dirty", attr.Value ? "true" : "false");
     		    }
     		    writer.WriteEndElement();
	     	}
	     	
	     	writer.WriteEndElement();   	
        }
    }
