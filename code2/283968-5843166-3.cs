        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawCaret(e.Graphics, 30, new Point(20, 20));
            DrawCaret(e.Graphics, 50, new Point(100, 100));
        }
        private static void DrawCaret(Graphics g, int scale, Point loc)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            int height = scale;
            int width = scale/10;
            int rectBase = scale/5;
            g.FillRectangle(Brushes.Black, loc.X, loc.Y, width, height);
            var path = new GraphicsPath();
            path.AddPolygon(new[]
                                {
                                    new Point(loc.X+width, loc.Y),
                                    new Point(loc.X+width+rectBase/2, loc.Y+rectBase/2),
                                    new Point(loc.X+width, loc.Y+rectBase),
                                });
            g.FillPath(Brushes.Black, path);
        }
