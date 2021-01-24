c#
private void PictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1.Image);
            MouseEventArgs me = (MouseEventArgs)e;
            Point cord= me.Location;
            color = b.GetPixel(cord.X,cord.Y); 
            solidColor = new Bitmap(pictureBox2.Width, pictureBox2.Height, PixelFormat.Format24bppRgb);
            using (Graphics grp = Graphics.FromImage(solidColor))
            {
                SolidBrush co = new SolidBrush(color);
                grp.FillRectangle(co, 0, 0, pictureBox2.Width, pictureBox2.Height);
            }
            pictureBox2.Image = solidColor;
        }
c#
