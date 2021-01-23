    public class SalesOnEachCountry
    {        
        [Key, Column(Order=0)] public int CountryId { get; set; }
        public string CountryName { get; set; }
        [Key, Column(Order=1)] public int OrYear { get; set; }
         
        public long SalesCount { get; set; }      
        public decimal TotalSales { get; set; }
    }
