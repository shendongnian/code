    public class Store {
        public int Id { get; set; }
    
        //Other properties
    
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
    
    public class StoreDetails {
        public int Id { get; set; }
    
        //Other properties
    
        public virtual ICollection<Product> Products { get; set; }
    }
