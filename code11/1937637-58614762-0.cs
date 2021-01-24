cs
    public class AllData
	{
		public Customer[] customer { get; set; }
		public Message[] message { get; set; }
	}
	public class Customer
	{
		public string phone { get; set; }
	}
	public class Message
	{
		public string type { get; set; }
	}
You should update property names or decorate with `JsonProperty` attribute. You also should specify getter and setter for collection properties
