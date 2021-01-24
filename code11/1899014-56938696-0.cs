    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.DrawRectangle(
            new Pen(Color.Red, 5) { Alignment = PenAlignment.Inset },
            new Rectangle(0, 0, 50, 50));
    }
