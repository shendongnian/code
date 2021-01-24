    class Program
    {
        static Point _position; //Points to latest position of something
        static void Move(int x, int y)
        {
            var temp = new Point(x, y);
            _position = temp;
        }
    }
