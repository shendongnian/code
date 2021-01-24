c#
pictureBox.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                   System.Drawing.Imaging.PixelFormat.DontCare);
Also, this must be called to prevent memory leakage.
c#
if (pictureBox.Image != null)
{
    pictureBox.Image.Dispose();
}
