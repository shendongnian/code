    public static class ColumnExtensions
    {
    	public static void OrderByProperties(this DataGridViewColumnCollection columns,  Type t)
    	{
    		var columnList = new List<KeyValuePair<string, int>>();
    		foreach (var prop in t.GetProperties())
    		{
    			var att = prop.GetCustomAttributes<ColumnOrder>( true).First();
    			if(att!=null)
    			{
    				columnList.Add(new KeyValuePair<string, int>(prop.Name,att.Order));
    			}
    		}
    
    		foreach (var order in columnList.OrderBy(a => a.Value).Select((value, i) => new {i, value }))
    		{
    			columns[order.value.Key].DisplayIndex = order.i;
    		}
    	}
    }
