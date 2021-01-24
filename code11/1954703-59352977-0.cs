    using Newtonsoft.Json;
    
    ...
    
    		internal static class MyConverter
    		{
    			internal static T Convert<T>(object source)
    			{
    				string json = JsonConvert.SerializeObject(source);
    				T result = JsonConvert.DeserializeObject<T>(json);
    				return result;
    			}
    		}
