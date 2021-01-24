    public WedgeCallout()
    {
        tb = new TextBox();
        Controls.Add(tb);
    }
    TextBox tb = null;
    GraphicsPath gp = new GraphicsPath();
    protected override void OnLayout(LayoutEventArgs levent)
    {
        tb.Size = new Size(Width - 10, Height / 2);
        tb.Location = new Point(5, 5);
        tb.BackColor = BackColor;
        tb.ForeColor = ForeColor ;
        tb.BorderStyle = BorderStyle.None;
        tb.Text = "Hiho";
        tb.Multiline = true;
        tb.TextAlign = HorizontalAlignment.Center;
        tb.Font = Font;
        SetRegion();
        base.OnLayout(levent);
    }
    protected override void OnBackColorChanged(EventArgs e)
    {
        base.OnBackColorChanged(e);
        tb.BackColor = BackColor;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (Tag == null) return;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using(SolidBrush brush = new SolidBrush(BackColor))
            e.Graphics.FillPath(brush, (GraphicsPath)Tag);
        using (Pen pen = new Pen(Color.DarkGray, 2f))
            e.Graphics.DrawPath(pen, (GraphicsPath)Tag);
        e.Graphics.TranslateTransform(-1, -1);
        using (Pen pen = new Pen(ForeColor, 2f))
            e.Graphics.DrawPath(pen, (GraphicsPath)Tag);
    }
    void SetRegion()
    {
        Rectangle r = ClientRectangle;
        int h = (int)(r.Height * 0.75f);
        if (gp != null) gp.Dispose();
        gp = new GraphicsPath();
        gp.AddPolygon(new PointF[]{   new Point(0,0),
            new Point(r.Width-1, 0),  new Point(r.Width-1, h),
            new PointF(50, h) ,       new Point(0, r.Height-1),
            new PointF(20, h),        new PointF(0, h)});
        Region = new Region(gp);
        Tag = gp;
    }
