    using (var db = new CassandraContext(keyspace: "keyspace_name", host: "localhost"))
    {
    	var fromDate = DateTime.Now.Subtract(new TimeSpan(0, 30, 0));
    	var toDate = DateTime.Now;
    	var family = db.GetColumnFamily<TimeUUIDType, AsciiType>("family_name");
    	var results = family.Get("row_key")
    	                    .Fetch(fromDate)
    	                    .TakeUntil(toDate)
    	                    .FirstOrDefault();
    }
