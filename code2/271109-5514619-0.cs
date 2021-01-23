        Rectangle rect = new Rectangle(0, 0, 100, 100);
        Point pnt1 = new Point(50, 50);
        Point pnt2 = new Point(300, 300);
        bool intersects = Intersects(pnt1, pnt2, rect);
        public static bool Intersects(Point a, Point b, Rectangle r)
        {
            return (r.Contains(a) && !r.Contains(b)) || (!r.Contains(a) && r.Contains(b));
        }
