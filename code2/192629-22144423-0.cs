    [XmlElement("Dictionary")]
    public List<KeyValuePair<string, string>> XMLDictionaryProxy
    {
    	get
    	{
    		return new List<KeyValuePair<string, string>>(this.Dictionary);
    	}
    	set
    	{
    		this.Dictionary = new Dictionary<string, string>();
    		foreach (var pair in value)
    			this.Dictionary[pair.Key] = pair.Value;
    	}
    }
    	
    [XmlIgnore]
    public Dictionary<string, string> Dictionary
    {
        get; set;
    }
