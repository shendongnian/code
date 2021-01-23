    while (!reader.EOF)
    {
    	bool needToRead = true;
    	if (reader.NodeType == XmlNodeType.Element)
    	{
    		switch (reader.Name)
    		{
    			case "tilerow":
    				currentRow = currentRow + 1;
    				Console.WriteLine("row found");
    				currentCol = 0;
    				break;
    
    			case "tilecol":
    				Console.WriteLine("col found");                                                                                                                         
    				currentTexture = reader.ReadElementContentAsFloat();                          
    				currentCol = currentCol + 1;
    				needToRead = false;
    				break;
    		}
    	}
    	if (needToRead)
    		reader.Read();
    }
