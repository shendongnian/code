    public class CoOrds
    {
        private int x, y;
    
        public CoOrds()
        {
            x = 0;
            y = 0;
        }
    
        public CoOrds(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    //inherits CoOrds:
    public class ColorCoOrds : CoOrds
    {
        public System.Drawing.Color color;
    
        public ColorCoOrds() : base ()
        {
            color = System.Drawing.Color.Red;
        }
    
        public ColorCoOrds(int x, int y) : base (x, y)
        {
            color = System.Drawing.Color.Red;
        }
    }
