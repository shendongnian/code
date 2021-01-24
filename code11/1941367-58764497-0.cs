    var response = new Bankproductsinfo
    {
    	Person = new Person
    	{
    		Data = new List<Data>
    		{
    			new Data
    			{
    				Key = "name",
    				Text = "John Doe"
    			}
    		}
    	}
    };
    
    var name = response.Person?.Data?.FirstOrDefault(d => d.Key == "name")?.Text;
