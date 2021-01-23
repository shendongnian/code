    public class Ball
    {
        int X;
        int Y;
        Color color;
        public Ball( int x, int y, Color c )
        {
            X = x; Y = y; color = c;
        }
        
        // Whatever else you have in your ball class goes here
    
        public bool Intersects( Rectangle rect )
        {
            return new Rectangle( this.X - 4, this.Y - 4, this.X, this.Y ).Intersects( rect );
        }
        
        public void MakeInvisible()
        {
            color = new Color( 0, 0, 0, 0 );
        }
    }
