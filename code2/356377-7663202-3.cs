    using System.Drawing;
    public class Shape
    {
        public Color Colour { get; private set; }
    
        public Shape(Color c)
        {
            this.Colour = c;
        }
    }
    var shape = new Shape(Color.FromArgb(203, 211, 48));
