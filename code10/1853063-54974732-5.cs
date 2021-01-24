        public void draw(Graphics g, Pen blackPen)
        {
            double xDiff, yDiff, xMid, yMid;
            Point[] points = new Point[6];
            points[0].X = 50;
            points[0].Y = 50;
            points[1].X = 150;
            points[1].Y = 150;
            points[2].X = 0;
            points[2].Y = 150;
            SolidBrush varbrush = new SolidBrush(Color.FromArgb(100, Color.Yellow));
            fillTriangle(g, varbrush, points);
        }
