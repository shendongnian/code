    public class Program
    {
    	public static void Main(string[] args)
    	{
    	   string data = @"{
    			'tables' : {
    					 'tableId1' : {
    							'name' : 'Table1'
    					},
    					'tableId2' : {
    					  'name' : 'Table2'
    					}
    			}
    		 }";
    		
    	    JObject deserializedObject = JsonConvert.DeserializeObject<JObject>(data);
    		
    		List<JObject> tableObjectList = deserializedObject["tables"]
    								.Cast<JProperty>()
    								.Select(x => x.Value)
    								.Cast<JObject>()
    								.ToList();
    								
    		List<string> tableIDList = deserializedObject["tables"]
    								.Cast<JProperty>()
    								.Select(x => x.Name)
    								.ToList();
            
            Console.WriteLine(JsonConvert.SerializeObject(tableObjectList, Formatting.Indented));
    		
    		Console.WriteLine(JsonConvert.SerializeObject(tableIDList, Formatting.Indented));
    	   
    	}
    }
