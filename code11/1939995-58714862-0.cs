    public class Account
    {
    
    [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
    public List<Industry> Industrys { get; set; } 
    
    }
