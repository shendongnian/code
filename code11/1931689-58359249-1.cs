    class FancyLabel : Panel
    {
        private bool IsMouseEntered;
        public FancyLabel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            UpdateStyles();
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(205, 205, 205);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            IsMouseEntered = true;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            IsMouseEntered = false;
            Invalidate();
        }
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Browsable(true)]
        public override string Text { get => base.Text; set => base.Text = value; }
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics G = e.Graphics;
            G.SmoothingMode = SmoothingMode.HighQuality;
            G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            SolidBrush bkBrush = IsMouseEntered ? new SolidBrush(Color.FromArgb(125, 170, 170, 170)) : new SolidBrush(Color.FromArgb(125, 45, 45, 45));
            Rectangle rec = new Rectangle(0, 0, Width - 1, Height - 1);
            G.FillRectangle(bkBrush, rec);
            SolidBrush txtBrush = new SolidBrush(ForeColor);
            StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            G.DrawString(Text, Font, txtBrush, rec, sf);
            
            bkBrush.Dispose();
            txtBrush.Dispose();
            sf.Dispose();
        }
    }
