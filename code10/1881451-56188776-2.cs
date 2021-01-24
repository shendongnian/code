    public class Order
    {
    	[JsonConverter(typeof(PriceConverter))]
    	public Price Price { get; set; }
    }
