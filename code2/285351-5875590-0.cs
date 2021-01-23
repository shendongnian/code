    class rbtNode
    {    
        private rbtNode _parent;
    
        public rbtNode Parent
        {
             get { return _parent; }
             set
             {
                 System.Diagnostics.Debug.Assert(value != null);
                 _parent = value;
             }
        }
        ....
