    class Key<Tx, Ty>
    {
        public Tx x;
        public Ty y;
        public Key(Tx x, Ty y)
        {
            this.x = x;
            thix.y = y;
        }
    }
    
    Dictionary<Key<Tx, Ty>, Tz> d;
