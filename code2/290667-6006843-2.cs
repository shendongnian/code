    public class ConsoleRectangle
    {
        private int hWidth;
        private int hHeight;
        private Point hLocation;
        private ConsoleColor hBorderColor;
        public ConsoleRectangle(int width, int height, Point location, ConsoleColor borderColor)
        {
            hWidth = width;
            hHeight = height;
            hLocation = location;
            hBorderColor = borderColor;
        }
        public Point Location
        {
            get { return hLocation; }
            set { hLocation = value; }
        }
        public int Width
        {
            get { return hWidth; }
            set { hWidth = value; }
        }
        public int Height
        {
            get { return hHeight; }
            set { hHeight = value; }
        }
        public ConsoleColor BorderColor
        {
            get { return hBorderColor; }
            set { hBorderColor = value; }
        }
        public void Draw()
        {
            string s = "╔";
            string space = "";
            string temp = "";
            for (int i = 0; i < Width; i++)
            {
                space += " ";
                s += "═";
            }
            for (int j = 0; j < Location.X ; j++)
                temp += " ";
            s += "╗" + "\n";
            for (int i = 0; i < Height; i++)
                s += temp + "║" + space + "║" + "\n";
            s += temp + "╚";
            for (int i = 0; i < Width; i++)
                s += "═";
            s += "╝" + "\n";
            Console.ForegroundColor = BorderColor;
            Console.CursorTop = hLocation.Y;
            Console.CursorLeft = hLocation.X;
            Console.Write(s);
            Console.ResetColor();
        }
    }
