    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        var image = Properties.Resources.RockstarComplete_641;
        if (image != null)
        {
            var g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 
                pictureBox1.Width - image.Width, 
                pictureBox1.Height - image.Height,
                image.Width,
                image.Height);
        }
    }
