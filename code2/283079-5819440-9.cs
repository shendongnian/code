    // compares property set to given parameters
    public SimpleRule : IFactoryRule
    {
        private readonly int a,b,c;
        public SimpleRule(a,b,c) { ... }
        
        public bool CanInstantiate(PropertySet propSet)
        {
            return
                propSet.a == a &&
                propSet.b == b &&
                propSet.c == c;
        }
    }
    
