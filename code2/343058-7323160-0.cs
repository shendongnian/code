    private Bitmap _bmp = new Bitmap(250, 250);
    public Form1()
    {
      InitializeComponent();   
      using (Graphics g = Graphics.FromImage(_bmp))
        g.Clear(SystemColors.Window);
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.DrawImage(_bmp, new Point(0, 0));
    }
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
      using (Graphics g = Graphics.FromImage(_bmp))
      {
        g.DrawString("Mouse Clicked Here!", panel1.Font, Brushes.Black, e.Location);
      }
      panel1.Invalidate();
    }
