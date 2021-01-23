    protected override OnTextChanged(EventArgs e)
    {
        using (Graphics g = CreateGraphics())
        {
            SizeF size = g.MeasureString(Text, Font);
            Width = (int)Math.Ceiling(size.Width);
        }
        base.OnTextChanged(e);
    }
