    class TransparentPanel : Panel 
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return createParams;
            }
        }
    
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
            e.Graphics.FillRectangle(brush,0,0,this.Width,this.Height);
        }
            
    }
