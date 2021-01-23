        private void panel1_Paint( object sender, PaintEventArgs e )
        {
            var p = sender as Panel;
            var g = e.Graphics;
            g.FillRectangle( new SolidBrush( Color.FromArgb( 0, Color.Black ) ), p.DisplayRectangle );
            Point[] points = new Point[4];
            points[0] = new Point( 0, 0 );
            points[1] = new Point( 0, p.Height );
            points[2] = new Point( p.Width, p.Height);
            points[3] = new Point( p.Width, 0 );
            Brush brush = new SolidBrush( Color.DarkGreen );
            g.FillPolygon( brush, points );
        }
