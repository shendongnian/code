    class Instrument
    {
        public string ClassCode { get; private set; }
        public string Ticker { get; private set; }
        public Instrument(ClassCode classCode, Ticker ticker)
        {
             ClassCode = classCode;
             Ticker = ticker
        }
    }
