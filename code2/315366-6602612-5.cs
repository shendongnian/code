        public class Listing
        {
            public Security Security { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public List<Quote> Quotes { get; set; }
        }
        public class Security
        {
            public string CIK {get; set;}
            public string Cusip {get; set;}
            public string Symbol {get; set;}
            public string ISIN {get; set;}
            public string Valoren {get; set;}
            public string Name {get; set;}
            public string Market {get; set;}
            public string CategoryOrIndustry {get; set;}
            public string Outcome {get; set;}
            public string Message {get; set;}
            public string Identity {get; set;}
            public string Delay { get; set; }
        }
        public class Quote
        {
            public DateTime Date { get; set; }
            public Double Last { get; set; }
            public Double Open { get; set; }
            public Double LastClose { get; set; }
            public Double High { get; set; }
            public Double Low { get; set; }
            public Double ChangeFromOpen { get; set; }
            public Double PercentChangeFromOpen { get; set; }
            public Double ChangeFromLastClose { get; set; }
            public Double PercentChangeFromLastClose { get; set; }
            public Double Volume { get; set; }
            public Double SplitRatio { get; set; }
            public Double LastAdjusted { get; set; }
            public Double OpenAdjusted { get; set; }
            public Double LastCloseAdjusted { get; set; }
            public Double HighAdjusted { get; set; }
            public Double LowAdjusted { get; set; }
            public Double ChangeFromOpenAdjusted { get; set; }
            public Double ChangeFromLastCloseAdjusted { get; set; }
            public Double VolumeAintdjusted { get; set; }
            public bool NotTraded { get; set; }
            public string Outcome { get; set; }
            public string Message { get; set; }
            public string Identity { get; set; }
            public int Delay { get; set; }
        }
