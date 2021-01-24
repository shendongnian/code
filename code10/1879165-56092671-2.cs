    int count = 5000;
    List<PointF> pinCoordinates = new List<PointF>();
    Random rnd = new Random(9);
    float zoomFactor = 1.5f;
    private void Button1_Click(object sender, EventArgs e)
    {
        // init a list of points
        pinCoordinates.Clear();
        Size sz = pictureBox1.ClientSize;
        Cursor = Cursors.WaitCursor;
        for (int i = 0; i < count; i++)
        {
            pinCoordinates.Add(new PointF(rnd.Next(sz.Width), rnd.Next(sz.Height)));
        }
        // now draw in one way or the other:
        if (radioButton1.Checked)
        {
            Graphics g = pictureBox1.CreateGraphics();
            DateTime dt0 = DateTime.Now;
            foreach (var p in pinCordinates)  DoDraw(g, p);
            sayTime(dt0);
        }
        else
        {
            pictureBox1.Invalidate();
        }
        Cursor = Cursors.Default;
    }
    private void PictureBox1_Paint(object sender, PaintEventArgs e)
    {
        DateTime dt0 = DateTime.Now;
        foreach (var p in pinCoordinates)  DoDraw(e.Graphics, p);
        sayTime(dt0);
    }
    void DoDraw(Graphics g, PointF p)
    {
        using (Pen pen = new Pen(Color.FromArgb(rnd.Next(1234567890))))
            g.DrawEllipse(pen, p.X * zoomFactor, p.Y * zoomFactor, 10, 10);
    }
    void sayTime(DateTime dt)
    {
        DateTime dt1 = DateTime.Now;
        label1.Text = (dt1 - dt).ToString("s\\.ffff");
    }
