    namespace ConsoleApp1
    {
    	[Serializable]
    	public class Device
    	{
    		public string Name { get; set; }
    		public string Type { get; set; }
    		public int Station { get; set; }
    		public Function Function { get; set; }
    	}
    
    	[Serializable]
    	public class Function
    	{
    		public string Name { get; set; }
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var file = "<some_path>";
    			using (var reader = new StreamReader(file))
    			{
    				var devices = (List<Device>)new XmlSerializer(typeof(List<Device>)).Deserialize(reader);
    				
    				// do something with devices.
    			}
    		}
    	}
    }
