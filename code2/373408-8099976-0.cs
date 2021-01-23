    struct WonkyNumber
    {
        private const double SCALE_FACTOR    = 1.0E+8          ;
        private int          _intValue        ;
        private int          _fractionalValue ;
        private double       _doubleValue     ;
        
        public int    IntegralValue
        {
            get
            {
                return _intValue ;
            }
            set
            {
                _intValue = value ;
                _doubleValue = ComputeDouble() ;
            }
        }
        public int    FractionalValue
        {
            get
            {
                return _fractionalValue ;
            }
            set
            {
                _fractionalValue = value ;
                _doubleValue     = ComputeDouble() ;
            }
        }
        public double DoubleValue
        {
            get
            {
                return _doubleValue ;
            }
            set
            {
                this.DoubleValue = value ;
                ParseDouble( out _intValue , out _fractionalValue ) ;
            }
        }
        
        public WonkyNumber( double value ) : this()
        {
            _doubleValue = value ;
            ParseDouble( out _intValue , out _fractionalValue ) ;
        }
        
        public WonkyNumber( int x , int y ) : this()
        {
            
            _intValue        = x ;
            _fractionalValue = y ;
            _doubleValue     = ComputeDouble() ;
            
            return ;
        }
        
        private void ParseDouble( out int x , out int y )
        {
            double remainder = _doubleValue % 1.0 ;
            double quotient  = _doubleValue - remainder ;
            
            x = (int)   quotient                   ;
            y = (int) Math.Round( remainder * SCALE_FACTOR ) ;
            
            return ;
        }
        
        private double ComputeDouble()
        {
            double value =     (double) this.IntegralValue
                         + ( ( (double) this.FractionalValue ) / SCALE_FACTOR )
                         ;
            return value ;
        }
        
        public static implicit operator WonkyNumber( double value )
        {
            WonkyNumber instance = new WonkyNumber( value ) ;
            return instance ;
        }
        
        public static implicit operator double( WonkyNumber value )
        {
            double instance = value.DoubleValue ;
            return instance ;
        }
        
    }
