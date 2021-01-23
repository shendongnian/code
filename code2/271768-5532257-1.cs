	    public void GenericAppend(string content)
	    {
	        if (!string.IsNullOrEmpty(content))
	            _body.Add(XElement.Parse(content));
	    }
