    class Foo
    {
        private static Dictionary<Type, XmlSerializer> xmls = new Dictionary<Type, XmlSerializer>();
    	
    	// ...
    	
    	public static object XmlDeserialize(string xml, Type objType)
    	{
    		StringReader stream = null;
    		XmlTextReader reader = null;
    		try
    		{
    			XmlSerializer serializer;
    			if(xmls.Contains(objType)) {
    				serializer = xmls[objType];
    			}
    			else {
    				serializer = new XmlSerializer(objType);
    				xmls[objType] = serializer;
    			}			
    			
    			stream = new StringReader(xml); // Read xml data
    			reader = new XmlTextReader(stream);  // Create reader
    			return serializer.Deserialize(reader);
    		}
    		finally
    		{
    			if(stream != null) stream.Close();
    			if(reader != null) reader.Close();
    		}
    	}
    }
