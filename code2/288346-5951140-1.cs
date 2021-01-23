    class Event
    {
    	public DateTime EventDate;
    	public string EventName;
    }
    
    List<Event> events = GetEvents();
    
    var grouped = events.GroupBy(e => e.EventDate.Date).OrderBy(g => g.Key);
        
    foreach (var grouping in grouped)
    {
     	Console.WriteLine(grouping.Key); // <-- this is the date
        	
      	foreach (Event e in grouping) // <-- this is the list of events
       	{
    	    Console.WriteLine(e.EventName); 
       	}
    }
