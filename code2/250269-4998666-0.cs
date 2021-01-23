    protected override void OnPaint(PaintEventArgs pe)
    {
        using (Font f = new Font(this.Font.FontFamily, 8f, FontStyle.Regular))
        {
            pe.Graphics.DrawString(
                "Foo",
                f,
                Brushes.Black,
                new PointF(5, 5),
                new StringFormat
                {
                    Alignment = StringAlignment.Near,
                });
            pe.Graphics.DrawString(
                "Bar",
                f,
                Brushes.Gray,
                new PointF(5, 20),
                new StringFormat
                {
                    Alignment = StringAlignment.Near,
                });
            pe.Graphics.DrawString(
                "Bar",
                f,
                Brushes.White,
                new PointF(5, 35),
                new StringFormat
                {
                    Alignment = StringAlignment.Near,
                });
        }
    }
