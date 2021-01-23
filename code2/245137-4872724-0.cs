        Point pos = Point.Empty;// or your initial position
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_drag)
            {
                pos = e.Location;
            }
        }
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (_drag)
            {
                g.DrawEllipse(_whitePen, pos.X, pos.Y, 10, 10); 
            }
        }
