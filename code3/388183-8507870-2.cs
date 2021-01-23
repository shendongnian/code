        int _offset = 0;
        double period = 20.0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int y = Height / 3; y < Height; y++)
            {
                using (Graphics g = CreateGraphics())
                {
                    Pen p = new Pen(GetColorFor(y - Height / 3));
                    g.DrawLine(p, 0, y, Width, y);
                    p.Dispose();
                }
            }
            _offset++;
        }
        private Color GetColorFor(int y)
        {
            double d = 10.0;
            double h = 20.0;
            double z = 0.0;
            if (y != 0)
            {
                z = d * h / (double)y + _offset;
            }
            double l = 128 + 127 * Math.Sin(z * 2.0 * Math.PI / period);
            return Color.FromArgb((int)l, (int)l, (int)l);
        }
