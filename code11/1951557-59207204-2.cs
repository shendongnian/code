    using Newtonsoft.Json;
    public class RootObject
	{
		public double price { get; set; }
	}
    public class Program
    {
        public static void Main()
        {
			var json = @"{""price"": ""0.002200""}";
			
			var root = JsonConvert.DeserializeObject<RootObject>(json);
			
			Console.WriteLine(root.price);
            // 0.0022
		}	
	}
