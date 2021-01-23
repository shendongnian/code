    class P
    {
        public List<P> children;
        public int Val1;
        public int Val2;
        public void Add( P p )
        {
            this.Val1 += p.Val1;
            this.Val2 += p.Val2;
        }
    }
