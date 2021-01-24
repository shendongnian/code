    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        var ellipse = new Ellipse {
            Rectangle = new Rectangle(e.X - 50, e.Y - 15, 100, 30),
            Angle = _theAngle
        };
        _ellipses.Add(ellipse);
        _theAngle += 30; // Just for test purpose.
        Invalidate(); // Redraw!
    }
