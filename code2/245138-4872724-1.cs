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
                Graphics g = e.Graphics;//The event handler sends us the graphics object to use for painting
                g.DrawEllipse(_whitePen, pos.X, pos.Y, 10, 10); 
            }
        }
