    Instrument instr = new Instrument("Hello", "World");
    class Instrument
    {
        public Instrument(string ClassCode, string Ticker) 
        {
            this.ClassCode = ClassCode;
            this.Ticker = Ticker;
        }
    
        public string ClassCode { get; private set; }
        public string Ticker { get; private set; }
    }
