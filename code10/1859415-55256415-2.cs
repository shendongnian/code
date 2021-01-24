     public class Result
     {
         public string  Date { get; set; }
         public int NumberOfDocs { get; set; }
     }
    			
     Map = events => from event in events
         where event.Code == "123"
         select new Result  
         {           
    	    Date = event.DateTime.Date
    	    NumberOfDocs = 1		 
         }	   
    	   
     Reduce = results => from result in results  
         group result by result.Date into g
    	 select new Result 
    	 {
    	    Date = g.Key,
    		Count = g.Sum(x => x.NumberOfDocs )
    	 }
