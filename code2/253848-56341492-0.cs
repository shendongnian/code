      static void Main(string[] args)
        {
        Point A = new Point() { x = 0 };
        MyPointDelegate<Point> move=(ref Point p)=> p.MoveRight();
        move(ref A);
        Console.Write(A.x);
        //A.x is one!
        }
 
    public delegate void MyPointDelegate<Point>(ref Point t);
    struct Point
    {
        public int x, y;
    
        public void MoveRight()
        {
            x++;
        }
    }
