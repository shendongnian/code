    List<Basket> _baskets = new List<Basket>();
    
    class Basket
    {
        private List<Payload> _payload = new List<Payload>();
    
        public List<Payload> Payload
        {
            get { return _payload; }
        }
    
        public double Weight
        { 
            get { /* calculate total weight */; }
        }
    }
    
    class Payload
    {
        public string Name { get; set; }
        public double Level1 { get; set; }
        public double Level2 { get; set; }
        public double Local_Weight { get; set; }
    }
