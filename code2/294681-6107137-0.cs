    public partial class Form1 : Form
    {
        private Bitmap _background;
        private bool _isShrouded;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (true == _isShrouded && null!=_background)
                e.Graphics.DrawImage(_background, 0, 0);
        }
        public void Shroud()
        {
            if (false == _isShrouded)
            {
                CreateScreenshot();
                HideControls();
                _isShrouded = true;
                this.Invalidate();
            }
        }
        public void Unshroud()
        {
            if (true == _isShrouded)
            {
                ShowControls();
                
                _isShrouded = false;
                
                this.Invalidate();
            }
            
        }
        private void HideControls()
        {
            foreach (Control control in this.Controls)
                control.Visible = false;
        }
        private void ShowControls()
        {
            foreach (Control control in this.Controls)
                control.Visible = true;
        }
        private void CreateScreenshot()
        {
            Rectangle area = this.RectangleToScreen(this.ClientRectangle);
            Bitmap screenGrab = new Bitmap(area.Width, area.Height);
            Brush dark = new SolidBrush(Color.FromArgb(128, Color.Black));
            Graphics g = Graphics.FromImage(screenGrab);
            g.CopyFromScreen(area.Location, Point.Empty, area.Size);
            g.FillRectangle(dark, 0, 0, area.Width, area.Height);
            g.Dispose();
            _background = screenGrab;
        }
    }
