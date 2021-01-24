     public class Prices
        {
            public Mtgo mtgo { get; set; }
            public MtgoFoil mtgoFoil { get; set; }
            public Paper paper { get; set; }
            public PaperFoil paperFoil { get; set; }
        }
        
        public class RootObject
        {
            public Prices prices { get; set; }
        }
