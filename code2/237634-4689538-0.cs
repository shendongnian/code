    ...
    bool isRootRead = false;
    while (_xtr.Read())
    {
    	if (_xtr.NodeType == XmlNodeType.Element)
    	{
    		if (!isRootRead)
    		{
    			if (_xter.Name == "Response")
    			{
    				// root found
    				isRootRead = true;
    			}
    			// jump to next node if root node / ignore other nodes till root element is read
    			continue;
    		}
    		_currentField = _xtr.Name;
    		_xtr.Read();
    		if (_xtr.NodeType == XmlNodeType.Text)
    		{
    			switch (_currentField)
    			{
    				case "Status":
    					Console.WriteLine(_xtr.Value); //we print to console for testing purposes, normally assign it to a variable here!
    					break;
    ...
