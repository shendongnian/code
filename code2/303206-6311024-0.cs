    private void InitOutput(object output)
    {
        if (output is Control)
        {
            Control c = (Control)output;
            c.Paint += new System.Windows.Forms.PaintEventHandler(c_Paint);
            // Invalidate needed to rise paint event
            c.Invalidate();
        }
    }
    private void c_Paint(object sender, PaintEventArgs e)
    {
        SolidBrush hb =  new SolidBrush(Color.Red);
        e.Graphics.FillRectangle(hb, 7, 10, 30 - 19, 5);
        e.Graphics.DrawString("test", DefaultFont, hb, new PointF(50, 50));
    }
