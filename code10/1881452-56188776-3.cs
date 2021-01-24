    [JsonConverter(typeof(PriceConverter))]
    public class Price 
    {
    	public decimal Value { get; set; }	
    }
