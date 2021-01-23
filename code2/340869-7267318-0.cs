    class X { } 
    class Y : X { }
    class Program 
    {
        static void Main(string[] args) 
        {
            X x1 = new Y();
            Y y1 = (Y)x1;   // Works
            X x2 = new X();
            Y y2 = (Y)x2;   // InvalidCastException
        }
    }
