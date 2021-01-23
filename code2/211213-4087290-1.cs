    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        SolidBrush brush = new SolidBrush(Color.Black);
        float percent = (float)(val - min) / (float)(max - min);
        Rectangle rect = this.ClientRectangle;
        rect.Width = (int)((float)rect.Width * percent);
        g.FillRectangle(brush, rect);
        brush.Dispose();
        g.Dispose();
    }
