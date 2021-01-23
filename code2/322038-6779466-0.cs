    public class Quote
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public static Quote FromData(Data.Quote input){
            if (input == null) return null;
            Quote output = new Quote()
            {
                Id = input.QuoteId,
                Type = input.Type
            };
            output.Rates = (from i in input.RateSets
                            select Rate.FromData(i)).ToList();
        }
    }
    public class Rate
    {
        public int Id { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        public static Rate FromData(Data.RateSet input)
        {
            if (input == null) return null;
            Rate output = new Rate()
            {
                Id = input.Id
            };
            output.Options = (from i in input.Options
                              select Option.FromData(i)).ToList();
            return output;
        }
    }
    public class Option
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public static Option FromData(Data.Option input)
        {
            if (input == null) return null;
            Option output = new Option()
            {
                Id = input.Id,
                Price = input.Price ?? 0m
            };
            return output;
        }
    }
    namespace Data {
        public class Quote
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
            public List<Option> Options { get; set; }
        }
        public class Option
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal? Price { get; set; }
        }
    }
