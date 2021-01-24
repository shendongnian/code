    Point p1;
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        p1 = e.Location;
    }
    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        MessageBox.Show($"dx = {e.Location.X - p1.X}, dy= {e.Location.Y - p1.Y}");
    }
