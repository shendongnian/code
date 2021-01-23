    //imports
    using MMExtensions;
    
    //your namespace
    namespace MMExtensions {
    	public static class DictionaryExtensions {
    		public static DataTable ToDataTable<TKey, TValue>(
    			this Dictionary<TKey, TValue> hashtable
    		){
    			var dataTable = new DataTable(hashtable.GetType().Name);
    			dataTable.Columns.Add("Key", typeof(object));
    			dataTable.Columns.Add("Value", typeof(object));
    			foreach (KeyValuePair<TKey, TValue> var in hashtable){
    				dataTable.Rows.Add(var.Key, var.Value);
    			}
    			return dataTable;
    		}
    	}
    	public static class HashtableExtensions {
    		public static DataTable ToDataTable(this Hashtable hashtable) {
    			var dataTable = new DataTable(hashtable.GetType().Name);
    			dataTable.Columns.Add("Key", typeof(object));
    			dataTable.Columns.Add("Value", typeof(object));
    
    			foreach (DictionaryEntry var in hashtable){
    				dataTable.Rows.Add(var.Key, var.Value);
    			}
    			return dataTable;
    		}
    	}
    }
