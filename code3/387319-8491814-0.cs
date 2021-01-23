    Bitmap bmp1;
    TextureBrush tb;
    Point _LastPoint;
    public Form1()
    {
      InitializeComponent();
      this.DoubleBuffered = true;
      bmp1 = new Bitmap(@"c:\image1.png");
      tb = new TextureBrush(new Bitmap(@"c:\image2.png"));
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        if (!_LastPoint.IsEmpty) {
          using (Graphics g = Graphics.FromImage(bmp1))
          using (Pen p = new Pen(tb, 15)) {
            p.StartCap = LineCap.Round;
            p.EndCap = LineCap.Round;
            g.DrawLine(p, _LastPoint, e.Location);
          }
        }
        _LastPoint = e.Location;
        this.Invalidate();
      }
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e) {
      _LastPoint = Point.Empty;
    }
    private void Form1_Paint(object sender, PaintEventArgs e) {
      e.Graphics.DrawImage(bmp1, new Point(0, 0));
    }
