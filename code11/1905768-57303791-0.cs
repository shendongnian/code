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
