    class SeeThroughPanel : Panel
    {
        public SeeThroughPanel()
        {
        }
    
        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                return cp;
            }
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), this.ClientRectangle);
        }
    }
