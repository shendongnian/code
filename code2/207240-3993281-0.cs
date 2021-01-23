			System.DateTime dTime = DateTime.Now();
			// tSpan is 0 days, 1 hours, 30 minutes and 0 second.
			System.TimeSpan tSpan 
				= new System.TimeSpan(0, 1, 3, 0); 
			System.DateTime result = dTime + tSpan;
