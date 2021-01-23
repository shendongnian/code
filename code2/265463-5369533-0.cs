    public class Prize 
    {
        private int _pence = 0;
        public int Pence 
        { 
          get { return _pence; }
          set { _pence = Math.Max(value, 0); }
        }
    
        public Price(int pence) 
        {
            Pence = pence;
        }
    }
