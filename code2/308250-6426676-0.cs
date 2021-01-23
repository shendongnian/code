    public BaseType
    {
        public string Model; 
        public int EngineSize; 
    }
    public RuntimeType : Base
    {
        public PointF Location; 
        public double Speed; 
    } 
    public NetworkType : Base
    {
        public double Speed; 
        public double distanceAwayFromYou;    
    }    
