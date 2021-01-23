    var materializedRequests = Requests.Where(x => !x.Resolved).ToList(); //Materialize list with a ToList call
    
    materializedRequests
    	.Where(x =>
    		!materializedRequests.Any(y => 
    			y.IncommingDateTime.ToLocalTime().Day == x.IncommingDateTime.ToLocalTime().Day
    		)
    	)
