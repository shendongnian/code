    public class Scanner : Panel
    {
        private Image _scanner;
        public Scanner()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            CreateScanner();
        }
        private void CreateScanner()
        {
            Bitmap scanner = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(scanner);
            g.DrawEllipse(Pens.Green, 25, 25, 250, 250);
            g.Dispose();
            _scanner = scanner;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int shortestSide = Math.Min(this.Width, this.Height);
            if (null != _scanner)
                e.Graphics.DrawImage(_scanner, 0, 0, shortestSide, shortestSide);
        }
    }
 
