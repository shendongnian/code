    // compares property set to given parameters
    public SimpleRule : IFactoryRule
    {
        private readonly int a,b,c;
        public ExactRule(a,b,c) { ... }
        
        public bool ShouldInstantiate(PropertySet propSet)
        {
            return
                propSet.a == a &&
                propSet.b == b &&
                propSet.c == c;
        }
    }
    
