    public Void Traverse(string myJsonString){
    
    		var jObj = JObject.Parse(jsonString);
    
    		foreach (var item in jObj)
    		{
    			if(item.Value["dataGeneratorType"].ToString().Equals("range")){
    				Console.WriteLine("Do some logic");
    			}
    			else if(item.Value["dataGeneratorType"].ToString().Equals("array")){
    				
    				if(item.Value["length"] != null){
    					Console.WriteLine("Length is present do more logic");
    				}
    				else
    				{
    					Console.WriteLine("No length property present do more logic");
    
    				}
    				
    				
    			}
    			else if(item.Value["dataGeneratorType"].ToString().Equals("object")){
    				
    				Console.WriteLine("It's an object");
    				Console.WriteLine(item.Value["dataGeneratorValue"]);
    
    				foreach (var nestedItem in item.Value["dataGeneratorValue"]){
    					Console.WriteLine("Nested Item");
    					Console.WriteLine(nestedItem);
    					//Recursive function call
                        Traverse(nestedItem.Value)//pass in as a json string
    				}
    				
    				
    			}
    
    
    		}
    		
    	}
    }
