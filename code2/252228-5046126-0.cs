    var img = new Bitmap();
    using (Graphics g = Graphics.FromImage(img)) {
        g.DrawLine(Pens.Black, x1, y1, x2, y2);
    }
    pictureBox1.Image = img;
