            protected void TabPage_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen arrow = new Pen(Brushes.Black, 4);
            arrow.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            e.Graphics.DrawLine(arrow, 10, 10, 100, 100);
            arrow.Dispose();
        }
