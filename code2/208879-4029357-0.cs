    public class AnalysisEntity
    {
    	private decimal _ca;
    	private decimal _cb;
    	private decimal _cc;
    	private bool calculate_a = false;
    	private bool calculate_b = false;
    	private bool calculate_c = false;
    	private bool calculate_d = false;
    	private bool calculate_e = false;
    	
        public decimal InputA { get { return a;} set { a=value; calculate_a = true; calculate_c = true; } }
        public decimal InputB { get { return b;} set { b=value; calculate_c = true; calculate_d = true; } }
        public decimal InputC { get { return c;} set { c=value; calculate_a = true; } }
    	
        public decimal CalculatedValueA
        {
            get 
    		{ 
    			if( calculate_a ) { _ca = InputA * InputC; calculate_a = false; calculate_b = true; }
    			return _ca; 
    		}
        }
    
        public decimal CalculatedValueB
        {
            get 
            {
    			if( calculate_b ) { _cb = (CalculatedValueA / FactorGenerator.ExpensiveOperation()); calculate_b = false; calculate_d = true; }
    			return _cb;
            } 
        }
    
        public decimal CalculatedValueC
        {
            get 
    		{ 
    			if( calculate_c ) { _cc = InputA * InputB; calculate_c = false; }
    			return _cc;
    		}
        }
    
        public decimal CalculatedValueD
        {
            get 
    		{ 
    			if( calculate_d ) { _cd = (CalculatedValueA * InputB) / CalculatedValueB; calculate_d = false; calculate_e = true; }
    			return _cd;		
    		}
        }
    
        public decimal CalculatedValueE
        {
            get 
    		{ 
    			if( calculate_e ) { _ce = CalculatedValueD / aConstant; calculate_e = false; }
    			return _ce;	
    		}
        }
    }
