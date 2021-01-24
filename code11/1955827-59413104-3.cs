    public class Program
    {
    	public static void Main()
    	{
    		var data = new Data() { DataName = "My Data Name" };
    		var dataType = new DataType() { DataTypeName = "My Data Type Name" };
    		
    		try
    		{
                // Log-> MyRule: Dataname:My Data Name1, DataTypeName: My Data Type Name
    			Definition.Name("MyDecision").SetRule(new MyRule()).Run(data, dataType);
    			
                // Log -> Func: Dataname:My Data Name1, DataTypeName: My Data Type Name
    			Definition.Name("MyDecision").SetRule((dataArg, dataTypeArg) => 
    			{
    				Console.WriteLine("Func: Dataname:{0}, DataTypeName: {1}", dataArg.DataName, dataTypeArg.DataTypeName);
    	  			return false;
    			}).Run(data, dataType);
    		}
    		catch(Exception ex)
    		{
    			Console.WriteLine("Error: ", ex.Message);
    		}
    	}
    }
