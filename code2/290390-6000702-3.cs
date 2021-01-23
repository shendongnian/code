    // Draw into bitmap
    Bitmap bmp = new Bitmap(150, 150);
    Graphics g = Graphics.FromImage(bmp);
    g.FillRectangle(Brushes.Green, new Rectangle(25, 75, 10, 30));
    // Set bitmap into picture box
    pictureBox1.Image = bmp;
