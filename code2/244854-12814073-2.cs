    Bitmap bmp = new Bitmap(listView1.Width, listView1.Height);
    using (Graphics g = Graphics.FromImage(bmp))
    {
        SolidBrush br1 = new SolidBrush(Color.White);
        g.FillRectangle(br1, 0, 0, listView1.Width, listView1.Height);
        g.DrawImage(Image, listView1.Width - Image.Width, listView1.Height - pictureBox1.Image.Height);
    }
    listView1.BackgroundImage = bmp;
