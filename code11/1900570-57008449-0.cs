    string[] strarray = new [] { "0", "1", "2", "3"};
    XmlSerializer serializer = new XmlSerializer(typeof(string[]));
    string myString;
    
    using (var sw = new StringWriter())
    {
    	using (var xw = XmlWriter.Create(sw))
    	{
    		serializer.Serialize(xw, strarray);
    		myString = sw.ToString();
    	}
    }
