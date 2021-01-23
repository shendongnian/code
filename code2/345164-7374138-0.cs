    class X
    {
    
       public virtual Vector3b SIZE { get { return new Vector3b(16, 16, 16); } }
    
        public virtual Vector3b MAX
        {
            get { return new Vector3b(
                        (byte)(this.SIZE.X - 1), 
                        (byte)(this.SIZE.Y - 1), 
                        (byte)(this.SIZE.Z - 1)); 
                }
        }
    }
    
    class Y : X
    {
        public virtual Vector3b SIZE { get { return new Vector3b(26, 26, 26); } }
    }
     X x = new X();
     var xmax = x.MAX ;// MAX uses X's SIZE
     Y y = new Y();
     var ymax = y.MAX ;// MAX uses Y's SIZE
