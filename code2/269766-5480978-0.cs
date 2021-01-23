    class SomeType
    {
        public string Security {get;set;}
        public DateTime Date {get;set;}
        public int zScore {get;set;}
    }
    var results = new List<SomeType>(); 
    results.Add(new { Security = secRank.Symbol, Date = sec.First().Date, zScore = zScore });
