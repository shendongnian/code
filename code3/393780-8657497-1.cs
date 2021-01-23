    public class SimpleNote:Note
    {
        public SimpleNote(Point position)
        {
            Location = position;
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Red, Location.X, Location.Y, 5, 5);
            g.DrawLine(new Pen(Color.Red), Location.X+5, Location.Y, Location.X+5, Location.Y-15);
        }
    }
    public class DifficultNote:Note
    {
        public DifficultNote(Point position)
        {
            Location = position;
        }
        public override void Draw(Graphics g)
        {
            SimpleNote left = new SimpleNote(Location);
            SimpleNote right = new SimpleNote(new Point(Location.X + 20, Location.Y));
            left.Draw(g);
            right.Draw(g);
            g.DrawLine(new Pen(Color.Red), Location.X+5, Location.Y - 15, Location.X+25, Location.Y-15);
        }
    }
    public class PictureNote:Note
    {
        private Image _image;
        public PictureNote(Image image, Point position)
        {
            Location = new Point(position.X - image.Width/2, position.Y - image.Height/2);
            _image = image;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(_image, Location);
        }
    }
