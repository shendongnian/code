    // Assuming there are no duplicate names. You need to change accordingly the Queries if there are duplicates
    public void UpdateKey(XDocument document,string key,string value)
    {
    	var node = document.Descendants("variable").First(x=>(string)x.Attribute("name")==key);
    	node.Attribute("value").Value = value;
    }
    
    public string ReadKey(XDocument document, string key)
    {
    	return document.Descendants("variable").First(x=>(string)x.Attribute("name")==key).Attribute("value").Value;
    }
