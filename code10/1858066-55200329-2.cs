    public class Program
    {
    	public static void Main(string[] args)
    	{
    	   string data = @"{
    			'tables' : {
    					 'tableId1' : {
    							'name' : 'Name_Of_The_Table'
    					},
    					'tableId2' : {
    					  'name' : 'Name_Of_The_Table'
    					}
    			}
    		 }";
    		
    	   RootObject deserializedObject = JsonConvert.DeserializeObject<RootObject>(data);
    		
    	   Console.WriteLine(JsonConvert.SerializeObject(deserializedObject, Formatting.Indented));
    	}
    }
        
    public class RootObject
    {
       [JsonProperty("tables")]
       public TableCollection Tables { get; set; }
    }
    
    public class TableCollection
    {
       [JsonProperty("tableId1")]
       public Table1 Table1 { get; set; }
    
       [JsonProperty("tableId2")]
       public Table2 Table2 { get; set; }
    }
    
    public class Table1
    {
       [JsonProperty("name")]
       public string Name { get; set; }
    }
    
    public class Table2
    {
       [JsonProperty("name")]
       public string Name { get; set; }
    }
