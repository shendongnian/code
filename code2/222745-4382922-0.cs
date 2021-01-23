    public class Shape
    {
    public float X { get; set; }
    public float Y { get; set; }
    public Image Image { get; set; }
    public bool Test_int(int x, int y)
        {
            if (((x <= this.x + (float)image.Width) && (x >= this.x)) && ((y <= this.y + (float)image.Height) && (y >= this.y)))
                return true;
            else
                return false;
        }
    }
    public class Line
    {
        public Shape A { get; set; }
        public Shape B { get; set; }
    }
