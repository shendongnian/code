    public class Processors
    {
    	public class GBR : IProcessor
    	{
    		public string Process(string text)
    		{
    			return $"{text} (processed with GBR rules)";
    		}
    	}
    
    	public class FRA : IProcessor
    	{
    		public string Process(string text)
    		{
    			return $"{text} (processed with FRA rules)";
    		}
    	}
    }
    
