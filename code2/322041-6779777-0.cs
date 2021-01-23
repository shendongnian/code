    // to
    public class Quote2
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
    }
    
    public class Rate
    {
        public int Id { get; set; }
        public virtual ICollection<Option2> Options { get; set; }
    }
    
    public class Option2
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
    }
    
    // from
    public class Quote1
    {
        public int QuoteId { get; set; }
        public string Type { get; set; }
        public string Destination { get; set; }
        public List<RateSet> RateSets { get; set; }
    }
    
    
    public class RateSet
    {
        public int Id { get; set; }
        public decimal ValueMin { get; set; }
        public decimal ValueMax { get; set; }
        public List<Option1> Options { get; set; }
    }
    
    public class Option1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
    
    void Main()
    {
    	var Quotes = new List<Quote1>();
    	
    	var newQuotes = Quotes
        .Select(x => new Quote2 {
            Id = x.QuoteId,
            Rates = x.RateSets == null ? null : x.RateSets.Select( y => new Rate {
                Id = y.Id,
                Options = y.Options == null ? null : y.Options.Select(z => new Option2 {
                    Id = z.Id,
                    Price = z.Price.Value
                }).ToList()}).ToList()}).ToList();
    }
