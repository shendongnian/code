    foreach (var dict in reportData)
    		{
    			var keys = new List<string>(dict.Keys);
    			foreach (string key in keys)
    			{
    				if (key == "Type")
    				{
    					if (dict[key] == "Deposit")
    					{
    						dict["TransAmount"] =   "-" +dict["TransAmount"] ;
    					}
    				}
    			}
    		}
