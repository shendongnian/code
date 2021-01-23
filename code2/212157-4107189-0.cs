    public struct Grid
    {
        public int x;
        public int y;
        public Grid(int xx, int yy)
        {
            x = xx;
            y = yy;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Grid g0 = GetGrid(1); Debug.Assert(g0.x == 1 && g0.y == 1);
            Grid g1 = GetGrid(4); Debug.Assert(g1.x == 2 && g1.y == 2);
            Grid g2 = GetGrid(8); Debug.Assert(g2.x == 2 && g2.y == 4);
            Grid g3 = GetGrid(9); Debug.Assert(g3.x == 3 && g3.y == 3);
            Grid g4 = GetGrid(20); Debug.Assert(g4.x == 4 && g4.y == 5);
            Grid g5 = GetGrid(30); Debug.Assert(g5.x == 5 && g5.y == 6);
            Grid g6 = GetGrid(99); Debug.Assert(g6.x == 9 && g6.y == 11);
        }
        public static Grid GetGrid(int n)
        {
            int columns = (int)Math.Sqrt(n);
            int lines   = (int)Math.Ceiling(n / (double)columns);
            return new Grid(columns, lines);
        }
