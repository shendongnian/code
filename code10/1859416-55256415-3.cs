public class Result
{
      public string Code { get; set; }
      public string  Date { get; set; }
      public int NumberOfDocs { get; set; }
}
    
         Map = events => from event in events        
             select new Result  
             {          
                Code = event.Code
        	    Date = event.DateTime.Date             
        	    NumberOfDocs = 1		 
             }	   
        	   
         Reduce = results => from result in results  
             group result by new 
             {
               result.Code,
               result.Date
             }
             into g
        	 select new Result 
        	 {
                Code = g.Key.Code
        	    Date = g.Key.DateTime.Date,
        		NumberOfDocs = g.Sum(x => x.NumberOfDocs )
        	 }
and then query
List<Result> queryResults = session.Query< Result, <Index_Name> >()
                    .Where(x => x.Code == "some-code-number")
                    .ToList();
  [1]: https://demo.ravendb.net/demos/auto-indexes/auto-map-reduce-index
  [2]: https://demo.ravendb.net/demos/static-indexes/map-reduce-index
