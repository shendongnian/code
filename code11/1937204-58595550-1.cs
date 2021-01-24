    private void SPREMI_Click(object sender, EventArgs e)
    {
        pictureBox1.Controls.Add(label1);
        Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
        panel1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
        bmp.Save(@"test.bmp");
    }
