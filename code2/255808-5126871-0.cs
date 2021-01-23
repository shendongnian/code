    class Derived : Base
    {
        string S;
        public Derived(string s, int n) : this(s,n,-1)
        {
        }
    
        public Derived(string s, int n, int m) : base(n, m)
        {
            S = s;
            // repeated    
        }
    }
