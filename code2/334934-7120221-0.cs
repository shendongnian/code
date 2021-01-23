    class MyControl : System.Windows.Forms.Control
    {
        Bitmap bmp;
        Graphics g;
        int x = 100;
        public MyControl()
        {
            this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer , true);
            bmp = new Bitmap(100, 100);
            g = Graphics.FromImage(bmp);
        }        
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            this.g.FillRectangle(Brushes.White, new Rectangle(0, 0, 100, 100));
            this.g.DrawString("Hello", this.Font, Brushes.Black, (float)x, 10);
            e.Graphics.DrawImage(bmp, new Point(0, 0));
            x--;
        }
    }
