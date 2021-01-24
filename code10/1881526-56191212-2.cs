     public class CarTypeEntity
         {
            [JsonProperty("Cars")]
            public List<CarType> Cars { get; set; }
         }
    public class CarType
     {
         [JsonProperty("Body style")]
         public string bodyStyle { get; set; }
    
         [JsonProperty("Color")]
         public string Color { get; set; }
         
         [JsonProperty("V-max")]
         public int vMax { get; set; }
       
         [JsonProperty("Gearbox type")]
         public string gearboxType { get; set; }
    
         [JsonProperty("Number of doors")]
         public int doorsNumber { get; set; }
    
         [JsonProperty("VIN number")]
         public string vinNumber { get; set; }
     }
