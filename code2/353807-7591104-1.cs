using(Bitmap bitMap = (Bitmap)Image.FromFile("myimage.jpg")) // assumes a 400 * 300 image from which a 160 * 120 chunk will be taken
{
using(Bitmap cropped = new Bitmap(160,120))
{
  using(Graphics g=Graphics.FromImage(cropped))
  {
    g.DrawImage(bitMap, new Rectangle(0,0,cropped.Width,cropped.Height),100,50,cropped.Width,cropped.Height,GraphicsUnit.Pixel);
    cropped.Save("croppedimage.jpg",ImageFormat.Jpeg);
  }
}
}
