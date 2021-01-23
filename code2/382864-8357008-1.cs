    public class Details {
        public string Pair { get; set; }
        public int Value { get; set; }
        public int Count { get; set; }
    }
    // selection only
    public readonly static List<Details> PairDetails = new List<Details>() {
        new Details{Pair = "0,1", Value = 3},
        new Details{Pair = "0,2", Value = 5},
        new Details{Pair = "1,5", Value = 34},
        new Details{Pair = "1,6", Value = 66},
        new Details{Pair = "2,3", Value = 12},
        new Details{Pair = "4,5", Value = 48}
    };
