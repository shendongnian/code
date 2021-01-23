    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        Graphics g = pevent.Graphics;
        g.DrawImage(splashImage, new Rectangle(0, 0, this.Width, this.Height));
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        //Do nothing here
    }
