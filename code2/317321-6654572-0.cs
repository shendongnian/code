    Bitmap temp = new Bitmap(new Size(pictureBox.Image.Width,pictureBox.Image.Height));
    using(Graphics g = Graphics.FromImage(temp))
    {
        g.DrawImage(img2, 0, 0);
    }
    img2 = temp;
