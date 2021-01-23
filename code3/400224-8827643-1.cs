    class Range
    {
        public int Low {get; set;}
        public int High {get; set;}
    
        public bool InRange(int val) { return val >= Low && val <= High; }
    }
