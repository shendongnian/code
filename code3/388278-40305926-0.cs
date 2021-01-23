    using (Pen pen1 = new Pen(Color.Black, 2))
    {
        e.Graphics.DrawRectangle(pen1, rect);
    }
    using (Pen pen2 = new Pen(Color.White, 2))
    {
        pen2.DashPattern = new float[] { 5, 5 };
        e.Graphics.DrawRectangle(pen2, rect);
    }
