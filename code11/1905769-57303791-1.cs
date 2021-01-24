    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var graphics        = e.Graphics;
        var clientRectangle = ClientRectangle;
        var font            = Font;
        var text            = Text;
        var textSize        = TextRenderer.MeasureText(text, font);
        var textBounds      = DrawingHelper.AlignInRectangle(clientRectangle, textSize, ContentAlignment.MiddleLeft);
        graphics.FillRectangle(new SolidBrush(SystemColors.Control), ClientRectangle);
        ControlPaint.DrawBorder(graphics, clientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Solid);
        TextRenderer.DrawText(graphics, text, font, textBounds, SystemColors.WindowText);
    }
    protected override void OnEnabledChanged(EventArgs e)
    {
        base.OnEnabledChanged(e);
        SetStyle();
    }
    public void SetStyle()
    {
        if (DesignMode)
            return;
        SetStyle(ControlStyles.UserPaint, !Enabled);
        Invalidate();
    }
    public static class DrawingHelper
    {
        public static Rectangle AlignInRectangle(Rectangle outer, Size inner, ContentAlignment alignment)
        {
            int x = 0;
            int y = 0;
            switch (alignment)
            {
                case ContentAlignment.BottomLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.TopLeft:
                    x = outer.X;
                    break;
                case ContentAlignment.BottomCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.TopCenter:
                    x = Math.Max(outer.X + ((outer.Width - inner.Width) / 2), outer.Left);
                    break;
                case ContentAlignment.BottomRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.TopRight:
                    x = outer.Right - inner.Width;
                    break;
            }
            switch (alignment)
            {
                case ContentAlignment.TopCenter:
                case ContentAlignment.TopLeft:
                case ContentAlignment.TopRight:
                    y = outer.Y;
                    break;
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                    y = outer.Y + (outer.Height - inner.Height) / 2;
                    break;
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomRight:
                case ContentAlignment.BottomLeft:
                    y = outer.Bottom - inner.Height;
                    break;
            }
            return new Rectangle(x, y, Math.Min(inner.Width, outer.Width), Math.Min(inner.Height, outer.Height));
        }
    }
