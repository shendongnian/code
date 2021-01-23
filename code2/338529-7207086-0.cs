    void Main()
    {
    	List<Alerts> alerts = new List<Alerts>();
    	alerts.Add(new Alerts(DateTime.Now.AddDays(-1)));
    	alerts.Add(new Alerts(DateTime.Now));
    
    	IQueryable<Alerts> qAlerts = alerts.AsQueryable();
    
    	var query1 = qAlerts.Select (a => a.Begins);
    	Console.WriteLine(query1.ElementType);
    	
    	var query2 = qAlerts.Select (a => a);
    	Console.WriteLine(query2.ElementType);
        var query3 = alerts.Select (a => a);
        Console.WriteLine(query3.AsQueryable().ElementType);
    }
    public class Alerts
    {
    	public DateTime Begins {get; set;}
    	public Alerts(DateTime begins)
    	{
    		Begins = begins;
    	}
    }
