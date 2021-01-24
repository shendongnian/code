    private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        pDown = e.Location;
        pictureBox1.Refresh();
    }
    private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (!e.Button.HasFlag(MouseButtons.Left)) return;
        rect = new Rectangle(pDown, new Size(e.X - pDown.X, e.Y - pDown.Y));
        using (Graphics g = pictureBox2.CreateGraphics())
        {
            pictureBox1.Refresh();
            g.DrawRectangle(Pens.Orange, rect);
        }
    }
    private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        Rectangle iR = ImageArea(pictureBox2);
        rect = new Rectangle(pDown.X - iR.X, pDown.Y - iR.Y, 
                             e.X - pDown.X, e.Y - pDown.Y);
        Rectangle rectSrc = Scaled(rect, pictureBox2, true);
        Rectangle rectDest = new Rectangle(Point.Empty, rectSrc.Size);
        Bitmap bmp = new Bitmap(rectDest.Width, rectDest.Height);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.DrawImage(pictureBox1.Image, rectDest, rectSrc, GraphicsUnit.Pixel);
        }
        pictureBox2.Image = bmp;
    }
