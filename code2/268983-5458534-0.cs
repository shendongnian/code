    void Main ()
    {
    
    	var rows = new [] {
    		new Student { Name = "A", Timestamp = DateTime.Now.AddHours (-1) },
    		new Student { Name = "A", Timestamp = DateTime.Now.AddHours (-3) },
    		new Student { Name = "B", Timestamp = DateTime.Now.AddHours (4) },
    		new Student { Name = "B", Timestamp = DateTime.Now.AddHours (1) },
    		new Student { Name = "B", Timestamp = DateTime.Now }
    	};
    	
    	var recentRows = from row in rows
    		group row by row.Name into studentRows
    		select studentRows.OrderByDescending (sr => sr.Timestamp).First ();
    
    	Console.WriteLine (recentRows);
    }
    
    
    class Student {
    	public string Name { get; set; }
    	public DateTime Timestamp { get; set; }
    }
