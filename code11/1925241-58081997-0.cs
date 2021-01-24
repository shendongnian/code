    public class Wrapper
    {
        
        [JsonProperty("")]  // rename json property to empty string - don't know if this will work
        public List<Product> Products { get; set; } = new List<Product>();
        public bool returnbasketid { get; set; }
    }
