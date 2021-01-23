    private Point _StartPoint;
    void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left)
        _StartPoint = e.Location;
    }
    void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        Point changePoint = new Point(e.Location.X - _StartPoint.X, 
                                      e.Location.Y - _StartPoint.Y);
        panel1.AutoScrollPosition = new Point(-panel1.AutoScrollPosition.X - changePoint.X,
                                              -panel1.AutoScrollPosition.Y - changePoint.Y);
      }
    }
