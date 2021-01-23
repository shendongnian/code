    bool flag = false;
    Bitmap image = null;
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (flag && image != null)
        {
            var g = e.Graphics;
            // -- Optional -- //
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // -- Optional -- //
            g.DrawImage(image,
                pictureBox1.Width - image.Width,
                pictureBox1.Height - image.Height,
                image.Width,
                image.Height);
        }
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        image = new Bitmap("someimage.png");
        flag = true;
        pictureBox1.Refresh(); //Causes it repaint.
    }
