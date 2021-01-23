    void Main()
    {
        Instrument instr1 = new Instrument
        {
            ClassCode = "Hello",
            Ticker = "World"
        };
        instr1.ClassCode = "123";              // is allowed
        Instrument instr2 = new Instrument
        {
            ClassCode = "Hello",
            Ticker = "World"
        }.Freeze();                            // <-- notice Freeze here
        instr2.ClassCode = "123";              // throws InvalidOperationException
    }
    
    public class Instrument
    {
        private string _ClassCode;
        private string _Ticker;
        private bool _IsFrozen;
        
        public string ClassCode
        {
            get { return _ClassCode; }
            set
            {
                ThrowIfFrozen();
                _ClassCode = value;
            }
        }
        
        public string Ticker
        {
            get { return _Ticker; }
            set
            {
                ThrowIfFrozen();
                _Ticker = value;
            }
        }
        
        private void ThrowIfFrozen()
        {
            if (_IsFrozen)
                throw new InvalidOperationException(
                    "Instrument object has been frozen");
        }
        
        public Instrument Freeze()
        {
            _IsFrozen = true;
            return this;
        }
        
        public bool IsFrozen
        {
            get
            {
                return _IsFrozen;
            }
        }
    }
