    class Instrument
    {
    
        private string _ClassCode;
        private string _Ticker;
    
        public Instrument(string ClassCode, string Ticker)
    {
    _ClassCode = ClassCode;
    _Ticker = Ticker;
    }
        public string ClassCode { get {return _ClassCode;}}
        public string Ticker { get {return _Ticker;} }
    }
