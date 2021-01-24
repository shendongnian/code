    public class Dart
    {
        private int x;
        private int y;
        private readonly Image image;
        public int X
        {
            get { return x; }
            set {x=value;}
        }
        public int Y
        {
            get { return y; }
            set {y=value; }
        }
        public Image Image
        {
            get
            {
                return image;
            }
        }
        public Dart()
        {
            this.X = 0;
            this.Y = 0;
            this.image = Image.FromFile("Dart.png");
        }
        public void PaintDart(Graphics g)
        {
            g.DrawImage(image, x, y);
        }
    }
