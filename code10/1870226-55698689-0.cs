	public class LookupResponseModel
	{
		public Lookup_Table_Data[][] Lookup_table_data { get; set; }
	
		public class Lookup_Table_Data
		{
			public string Key { get; set; }
			public object Value { get; set; }
		}
	}
	
    // This will break the result up into an Array of Dictionaries
    // that are easier to work with
	Dictionary<string, object>[] MakeTables(LookupResponseModel lrm)
	{
		return lrm.Lookup_table_data.Select( entry => entry.ToDictionary( e => e.Key, e => e.Value ) ).ToArray();
	}
	
    // This will help you find the dictionary that has the values you want
	Dictionary<string, object> FindTable( Dictionary<string, object>[] tables, string key, object value )
	{
		return tables.Where( dict => dict.TryGetValue(key, out object val) && (value == val) ).Single(); 
	}
	
    // Here is how you might use them together
	string GetLabel()
	{
		var lrm = new LookupResponseModel();  // Parse the JSON
		var lookup = MakeTables(lrm);
		
		var table = FindTable( lookup, "id", 1 );
		
		return table["label"].ToString();  // Returns "something_else"
	}
