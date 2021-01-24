    public class Magazine
    {
        public string Publication { get; set; }
        public string Abbreviation { get; set; }
        public string Language { get; set; }
        public Func<string, bool> Predicate { get; set; }
    } 
    private List<Magazine> _magazines = new List List<Magazine>
    {
        new Magazine
        {
            Publication = "Anti-âge Magazine",
            Abbreviation = "aamfr",
            Language ="fr",  
            Predicate = source => source.StartsWith("aamfr")       
        }
    }
