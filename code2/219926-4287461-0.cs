    protected override void OnPaintBackground (System.Windows.Forms.PaintEventArgs e)
    {
        Rectangle rDisplay = new Rectangle(0, 0, this.Width, this.Height);
        using (LinearGradientBrush lgb = new LinearGradientBrush(rDisplay, Color.WhiteSmoke, Color.SteelBlue, LinearGradientMode.Vertical))
        {
            e.Graphics.FillRectangle(lgb, rDisplay);
        }
    }
