    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        using (Pen p = new Pen(Color.Red, 3))
        using (Bitmap bmp = new Bitmap(700, 900))
        using (Graphics gr = Graphics.FromImage(bmp))
        {
           gr.DrawLine(p, new Point(30, 30), new Point(80, 120));
           gr.DrawEllipse(p, 30, 30, 80, 120);
           bmp.Save(@"C:\testBMP.jpeg", ImageFormat.Jpeg);
        }
    }
