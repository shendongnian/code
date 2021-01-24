    var tbl = new DataTable();
    new SqlDataAdapter(cmd, "your connection string here").Fill(tbl);
    
    var data = new 
    {
    	MetaData = tbl.AsEnumerable()
    		.Select(t => new { Key = t.Field<string>("KeyColumn"), Value = t.Field<string>("ValueColumn")}),
    	Length = 25,
    	Type = "application/mp3"
    };
    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
