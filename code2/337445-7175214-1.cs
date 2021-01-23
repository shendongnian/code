    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.DrawImage(pictureBox1.Image, pictureBox1.Width - pictureBox1.Image.Width, pictureBox1.Height - pictureBox1.Image.Height);
    }
