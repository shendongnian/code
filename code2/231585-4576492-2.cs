    public int GetMaxChars(TextBox tb)
    {
        using (var g = CreateGraphics())
        {
            return (int)Math.Floor(tb.Width / (g.MeasureString("0123456789", tb.Font).Width / 10));
        }
    }
