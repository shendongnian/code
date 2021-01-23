    private Point oldLocation = Point.Empty;
    private void pictureBox1_MouseMove ( object sender, MouseEventArgs e )
    {
        if (e.Location.X != oldLocation.X || e.Location.Y != oldLocation.Y)
        {
            oldLocation = e.Location;
            label1.Text = DateTime.Now.ToLongTimeString ( ) + ": " + e.X + "," + e.Y;
        }
    }
