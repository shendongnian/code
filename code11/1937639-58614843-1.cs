    using Newtonsoft.Json;
	public class AllData
	{
		public class Message
		{
			public String Type;
		}
		public class Customer
		{
			public String Phone;
		}
		[JsonProperty(PropertyName = "message")]
		public List<Message> Messages = new List<Message>();
		
		[JsonProperty(PropertyName = "customer")]
		public List<Customer> Customers = new List<Customer>();
	}
