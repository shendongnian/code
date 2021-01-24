    IEnumerable<object> options = (IEnumerable<object>)((GenericRecord)response.Message.Value["Product"])["Options"];
    	foreach (var data in options)
    	{
    		OptionData optionData = new OptionData()
    		{
    			PrimaryColour = new Colour()
    			{
    				Name = (string)((GenericRecord)((GenericRecord)data)["PrimaryColour"])["Name"],
    			},
    			SecondaryColour = new Colour()
    			{
    				Name = (string)((GenericRecord)((GenericRecord)data)["SecondaryColour"])["Name"]
    			},
    			Sizes = new List<SizeData>() // Initialize Collection Here	
    		};
    		
    		IEnumerable<object> SizesEnumerable = (IEnumerable<object>)(((GenericRecord)data)["Sizes"]);
    
    		foreach (var size in SizesEnumerable)
    		{
    			var sizeValue = new SizeData
    			{
    				KeycodeNumber = (string)((GenericRecord)size)["KeycodeNumber"],
    				Size = new Size
    				{
    					Name = (string)((GenericRecord)((GenericRecord)size)["Size"])["Name"]
    				}
    			};
    			
    			((List<SizeData>)optionData.Sizes).Add(sizeValue); // Add Data here
    		}
    	}
