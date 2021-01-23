    using MMExtensions;
    
    namespace MMExtensions
    {
    	public static class DictionaryExtensions
    	{
    		public static DataTable ToDataTable<TKey, TValue>(this Dictionary<TKey, TValue> hashtable)
    		{
    			var dataTable = new DataTable(hashtable.GetType().Name);
    			dataTable.Columns.Add("Key", typeof(object));
    			dataTable.Columns.Add("Value", typeof(object));
    			foreach (KeyValuePair<TKey, TValue> var in hashtable)
    			{
    				dataTable.Rows.Add(var.Key, var.Value);
    			}
    			return dataTable;
    		}
    	}
    }
