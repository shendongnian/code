    protected override void OnPaint(PaintEventArgs e)
    {
        // Call the base class first
        base.OnPaint(e);
        // Then insert your custom drawing code
        Rec = new Rectangle(UpX, UpY, DwX - UpX, DwY - UpY);
        using (Pen pen = new Pen(Color.Red, 2))
        {
            e.Graphics.DrawRectangle(pen, Rec);
        }
    }
