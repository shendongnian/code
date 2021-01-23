    void Main()
    {
    	var events = new List<Event>
    	{
    		new Event(1, DateTime.Now),
    		new Event(1, DateTime.Now.AddDays(1)),
    		new Event(2, DateTime.Now.AddDays(2)),
    		new Event(2, DateTime.Now.AddDays(-22)),
    	};
    	
    	var distinct = events.GroupBy(evt => evt.Id).Select(grp => grp.Min());
    }
    public class Event : IComparable<Event>
    {
    	public Event(int id, DateTime exp)
    	{
    		Id = id;
    		Expiration = exp;
    	}
     	public int Id {get; set;}
    	public DateTime Expiration {get; set;}
    	
    	public int CompareTo(Event other)
    	{
    		return Expiration.CompareTo(other.Expiration);
    	}
    }
