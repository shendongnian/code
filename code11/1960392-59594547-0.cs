c#
using System.Drawing;
using System.Drawing.Drawing2D;
//...
public static void CropImage(ref Bitmap src, int left, int right, int top, int bottom)
{
    Rectangle rectSrc = new Rectangle(0, 0, src.Width, src.Height);
    Rectangle rectOut = new Rectangle(
        left, 
        top, 
        rectSrc.Width - (left + right), 
        rectSrc.Height - (top + bottom)
        );
    if (src == null || rectOut.Width <= 0 || rectOut.Height <= 0)
        return;
    Bitmap bmpOut = new Bitmap(rectOut.Width, rectOut.Height);
    using (var g = Graphics.FromImage(bmpOut))
    {
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.Clear(Color.Transparent);
        g.DrawImage(
            src, 
            new Rectangle(0, 0, rectOut.Width, rectOut.Height), 
            rectOut, 
            GraphicsUnit.Pixel
            );
        src.Dispose();
        src = (Bitmap)bmpOut.Clone();
    }
}
And call the method for example as follows:
c#
var src = (Bitmap)pictureBox1.Image;
CropImage(ref src, 10, 10, 10, 10);
pictureBox1.Image = src;
