            public string GetQueryValue(string queryKey)
    		{
    			foreach (string key in QueryItems)
    			{
    				if(queryKey.Equals(key, StringComparison.OrdinalIgnoreCase))
    					return QueryItems.GetValues(key).First(); // There might be multiple keys of the same name, but just return the first match
    			}
    			return null;
    		}
