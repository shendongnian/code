        public bool TestOne(int l, int e, int u, int r)
        {
            return (l != e && l != u && l != r);
        }
    
        public bool TestTwo(int l, int e, int u, int r)
        {
            return (!(l == e || l == u || l == r));
        }
