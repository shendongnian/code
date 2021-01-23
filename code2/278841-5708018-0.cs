    class Instrument {
        public Instrument(string ClassCode = null, string Ticker = null)
        {
            this.ClassCode = ClassCode;
            this.Ticker = Ticker;
        }
        public string ClassCode { get; private set; } 
        public string Ticker { get; private set; } 
    }
