    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        var image = Properties.Resources.SomeImage;
        if (image != null)
        {
            var g = e.Graphics;
            g.DrawImage(image, 
                pictureBox1.Width - image.Width, 
                pictureBox1.Height - image.Height,
                image.Width,
                image.Height);
        }
    }
