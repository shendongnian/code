    // pictureBox1 image
    // pictureBox2 enlarged image
    Image image;
    private void Form1_Load(object sender, EventArgs e)
    {
        pictureBox1.Image = Image.FromFile(@"D:\pic\a.jpg");
        image = pictureBox1.Image;
    }
    private void pictureBox1_MouseHover(object sender, EventArgs e)
    {
        pictureBox1.Image = null;
        pictureBox2.Image = image;
    }
    private void pictureBox1_MouseLeave(object sender, EventArgs e)
    {
        pictureBox1.Image = image;
        pictureBox2.Image = null;
    }
