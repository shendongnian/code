    private Line Line = new Line();
    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.DrawLine(Pens.Red, this.Line.Start, this.Line.End);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            this.Line.Start = e.Location;
            this.Refresh();
        }
        else if (e.Button == MouseButtons.Right)
        {
            this.Line.End = e.Location;
            this.Refresh();
        }
    }
