        public void draw(Pen blackPen)
        {
            Graphics draw = CreateGraphics();
            Point[] points = new Point[6];
            points[0].X = 0;
            points[0].Y = 0;
            points[1].X = 150;
            points[1].Y = 150;
            points[2].X = 0;
            points[2].Y = 150;
                       
            using (SolidBrush fillvar = new SolidBrush(Color.FromArgb(100, Color.Yellow)))
            {
                draw.FillPolygon(fillvar, points.ToArray());
                draw = CreateGraphics();
                draw.DrawPolygon(Pens.DarkBlue, points);
            }
        }
