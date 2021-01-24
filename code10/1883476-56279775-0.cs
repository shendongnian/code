    class Program
    {
        static Random R = new Random();
        static void Main(string[] args)
        {
            List<Position> positions = new List<Position>();
            for (int i = 0; i < 100; i++)
            {
                Position tempPosition = new Position();
                tempPosition.x = R.Next(Console.WindowWidth);
                tempPosition.y = R.Next(Console.WindowHeight - 1);
                // ... set other properties of tempPosition ...
                positions.Add(tempPosition);
            }
            DrawMap(positions);
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("Press Enter to Quit");
            Console.ReadLine();
        }
        static void DrawMap(List<Position> mapData)
        {
            Console.Clear();
            foreach (Position p in mapData)
            {
                p.Draw();
            }
        }
    }
    class Position
    {
        public int x;
        public int y;
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("@");
        }
    }
